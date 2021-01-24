    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            List<Drop> rain = new List<Drop> (); // keeps all drops in one place
            Random rnd = new Random ();          // for generating random numbers
            public Form1 ()
            {
                InitializeComponent ();
                for (int i = 0; i < 100; i++) // creates 100 drops at random position and with random speed
                    rain.Add (CreateRandomDrop ());
            }
            private Drop CreateRandomDrop ()
            {
                return new Drop // create drop with random position and speed
                {
                    Position = new PointF (rnd.Next (this.Width), rnd.Next (this.Height)),
                    YSpeed   = (float) rnd.NextDouble () * 3 + 2 // 2..5
                };
            }
            private void UpdateRain () // changes Y position for each drop (falling), also checks if a drop is outside Main form, if yes, resets position to 0
            {
                foreach (var drop in rain)
                {
                    drop.Fall ();
                    if (drop.Position.Y > this.Height)
                        drop.Position.Y = 0;
                }
            }
            private void RenderRain ()
            {
                using (var grp = this.CreateGraphics ()) // using will call IDisposable.Dispose
                {
                    grp.Clear (Color.DarkBlue);
                    foreach (var drop in rain)
                        grp.DrawLine (Pens.White, drop.Position, new PointF (drop.Position.X, drop.Position.Y + 3));
                }
            }
            private void timer1_Tick (object sender, EventArgs e)
            {
                UpdateRain ();
                RenderRain ();
            }
        }
        class Drop
        {
            public PointF Position;
            public float  YSpeed;
            public void Fall () => Position.Y += YSpeed;
        }
    }
