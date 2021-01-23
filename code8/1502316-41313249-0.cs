    using System;
    using System.Threading;
    using System.Windows.Media;
    namespace Xx
    {
      class Yy
      {
        MediaPlayer p46 = new MediaPlayer(); // field (class-level variable), 'var' not allowed
        void Test_KeyDown(object sender, KeyEventArgs e)
        {
          if (e.KeyCode == Keys.OemPeriod)
          {
            // can see p46 here:
            p46.Open(new Uri(@"C:\Users\Shawn\Desktop\Sonstiges\LaunchBoard\LaunchBoard\bin\Debug\Sounds\Song1Audio41.wav"));
            p46.Volume = TrackWave.Value / 10.00;
            p46.Play();
            Thread.Sleep(50);
            button19.BackColor = Color.Red;
          }
        }
        void Test_KeyUp(object sender, KeyEventArgs e)
        {
          // can see p46 here:
        }
      }
    }
