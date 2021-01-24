    using System;
    using System.Threading;
    using System.Windows.Media;
    
    namespace SoundBoardApp
    {
        public static class Soundboard
        {
            private static bool _isBusy = false;
    
            public static bool IsBusy { get { return _isBusy; } }
    
            private static void MediaEndedHandler(object sender, EventArgs e)
            {
                _isBusy = false;
                var wmp = ((MediaPlayer)sender);
                wmp.MediaEnded -= new EventHandler(MediaEndedHandler);
                wmp.Close();            
            }
    
            public static bool PlaySound(string filename)
            {
                if (!_isBusy)
                {
                    _isBusy = true;
                    var wmp = new MediaPlayer();
                    wmp.MediaEnded += new EventHandler(MediaEndedHandler);
                    wmp.Volume = 0.5;
                    wmp.Open(new Uri(filename));
                    wmp.Play();
                    return true;
                }
                else
                {
                    return false;
                }            
            }
    
        }
    
        public class StayAliveBot
        {
            public void Live()
            {
                while (true)
                {
                    Thread.Sleep(1500000);
                    if (!Soundboard.IsBusy) Soundboard.PlaySound("C:\\SoundboardOpFiles\\TestTone.wav");
                }
            }
        }
    }
