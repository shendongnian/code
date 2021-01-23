        List<string> words = new List<string>();
        DispatcherTimer timer= new DispatcherTimer();;
        int cur = 0;
        public TestPage()
        {
           
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,2);
            timer.Tick +=timerTick;
            timer.Start();
        }
            private void timerTick(object sender, object e)
        {
          if(cur<words.Count){
            path = Dictionary.wordchecker(words[cur]);//Checks words for Animation
            pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\images\\" + path + ".gif");
            textBox1.Text = s;
            cur++;
           }else{
              timer.Stop();
           }
        }
