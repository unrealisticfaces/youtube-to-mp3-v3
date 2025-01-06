using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace youtube_to_mp3_v3
{
    public partial class Form1 : Form
    {
        private string selectedDownloadFolder;
        public Form1()
        {
            InitializeComponent();
            selectedDownloadFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async Task<bool> DownloadYoutubeToMp3Async(string url)
        {
            try
            {
                Console.WriteLine($"Attempting to download: {url}");

                var youtube = new YoutubeClient();

                // Get the video ID from the URL
                var videoId = VideoId.Parse(url);

                // Get the video metadata
                var video = await youtube.Videos.GetAsync(videoId);
                string sanitizedTitle = SanitizeFileName(video.Title);

                if (string.IsNullOrEmpty(sanitizedTitle))
                {
                    MessageBox.Show($"The video title for {url} is not valid for a file name.");
                    return false;
                }

                // Get the stream manifest
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
                var audioStreamInfo = streamManifest.GetAudioOnlyStreams().OrderByDescending(x => x.Bitrate).FirstOrDefault();

                if (audioStreamInfo != null)
                {
                    var downloadsPath = Path.Combine(selectedDownloadFolder, sanitizedTitle + ".mp3");

                    using (var fileStream = new FileStream(downloadsPath, FileMode.Create, FileAccess.Write))
                    {
                        var totalBytes = audioStreamInfo.Size.Bytes;
                        long totalBytesDownloaded = 0;

                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        using (var response = await youtube.Videos.Streams.GetAsync(audioStreamInfo))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;
                            while ((bytesRead = await response.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                totalBytesDownloaded += bytesRead;

                                double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds;
                                double downloadSpeedKbps = (totalBytesDownloaded / 1024) / elapsedTimeInSeconds;

                                label2.Invoke(new Action(() =>
                                {
                                    label2.Text = $"{downloadSpeedKbps:F2} KB/s";
                                }));

                                double progressPercent = (double)totalBytesDownloaded / totalBytes;
                            }
                        }

                        stopwatch.Stop();

                        label2.Invoke(new Action(() =>
                        {
                            label2.Text = $"Downloaded: {sanitizedTitle}.mp3";
                        }));
                        return true; // Indicate success
                    }
                }
                else
                {
                    MessageBox.Show($"Could not find a suitable audio stream for {url}.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading {url}: {ex.Message}");
                MessageBox.Show($"An error occurred while downloading {url}: {ex.Message}");
                return false;
            }
        }

        private string SanitizeFileName(string fileName)
        {
            var invalidChars = System.IO.Path.GetInvalidFileNameChars();
            var sanitizedFileName = string.Join("_", fileName.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries));
            const int maxFileNameLength = 255;
            if (sanitizedFileName.Length > maxFileNameLength)
            {
                sanitizedFileName = sanitizedFileName.Substring(0, maxFileNameLength);
            }

            return sanitizedFileName.Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = selectedDownloadFolder; // Show the current folder in the dialog
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    selectedDownloadFolder = folderBrowserDialog.SelectedPath;
                    // You might want to display the selected folder path in a label or textbox
                    // For example: label4.Text = selectedDownloadFolder;
                }
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string[] urls = textBox1.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (urls.Length == 0)
            {
                MessageBox.Show("Please enter valid YouTube URLs.");
                return;
            }

            int successfulDownloads = 0;

            foreach (var url in urls)
            {
                if (await DownloadYoutubeToMp3Async(url))
                {
                    successfulDownloads++;
                }
            }

            if (successfulDownloads == urls.Length)
            {
                MessageBox.Show("All links downloaded successfully!", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.facebook.com/kthdavidx/";

            try
            {
                Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] urls = textBox1.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (urls.Length == 0)
            {
                MessageBox.Show("Please enter URLs in the textbox.", "No URLs Entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var duplicateUrls = urls.GroupBy(x => x) // Group URLs by their value
                                  .Where(g => g.Count() > 1) // Filter out groups with only one occurrence (no duplicates)
                                  .Select(g => g.Key) // Select the URL (the key of the group)
                                  .ToList();

            if (duplicateUrls.Any())
            {
                string message = "The following duplicate URLs were found:\n\n" +
                                 string.Join("\n", duplicateUrls);
                MessageBox.Show(message, "Duplicate URLs Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("No duplicate URLs were found.", "No Duplicates", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

         
            int x = this.Location.X + this.Width; 
            int y = this.Location.Y; 

            form2.StartPosition = FormStartPosition.Manual; 
            form2.Location = new Point(x, y);

            form2.Show();
        }
    }
}
