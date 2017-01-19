using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Win32;
using System.IO;

namespace WpfTutorialSamples.Audio_and_Video
{
    public partial class MediaPlayerAudioControlSample : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MediaPlayerAudioControlSample()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null)
                lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
                lblStatus.Content = "Veuillez ouvrir un fichier .mp3";
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            //while(listBox.SelectedItem.ToString.btnPlay_Click != null)
            //{
            //    mediaPlayer.Play();
            //}
            mediaPlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
                mediaPlayer.Open(new Uri(openFileDialog.FileName));

            string fileN;
            fileN = Path.GetFileName(openFileDialog.FileName);

            listBox.Items.Add(fileN);
        }

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }

        private void NewCommand_CanExecute(object sender, RoutedEventArgs e)
        {
            //e.ToString = true;
        }

        private void NewCommand_Executed(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The New command was invoked");
        }
    }
}