using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;


namespace WPFVideo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void TimerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan newPosition = TimeSpan.FromSeconds(media.NaturalDuration.TimeSpan.TotalSeconds * e.NewValue);
            media.Position = newPosition;
        }


        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
         OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";

            if (dlg.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(dlg.FileName);

                media.Source = new Uri(fileInfo.FullName);
                Title = fileInfo.FullName;
                return;
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
           media.Stop();
        }


        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
           media.Pause();
        }


        private void media_Loaded(object sender, RoutedEventArgs e)
        {
         
        }

        private void btnMute_Click(object sender, RoutedEventArgs e)
        {

            if (media.Volume == 100)
            {
                media.Volume = 0;
                btnMute.Content = "Un-Mute";
            }
            else
            {
                media.Volume = 100;
                btnMute.Content = "Mute";
            }
      
    }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Volume = (double)volumeSlider.Value;
        }

        private void scroller_LostMouseCapture(object sender, MouseEventArgs e)
        {
            TimeSpan time = new TimeSpan(0, 0, Convert.ToInt32(Math.Round(scroller.Value))); 
            media.Position = time; 
        }

        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            scroller.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds;
        }
    }
}
