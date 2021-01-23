            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,2);
            timer.Tick +=timerTick;
        }
            private void timerTick(object sender, object e)
        {
            path = Dictionary.wordchecker(words[cur]);//Checks words for Animation
            pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\images\\" + path + ".gif");
            textBox1.Text = s;
            cur++;
        }
