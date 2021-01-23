    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    List<string> words = new List<string>();
        
        int cur = 0;
    
        public static int Main()
        {
            //2000 is two seconds you can adjust to the amount you need
            timer.Interval = 2000;
            timer.Tick += timerTick;
            timer.Start();
        }
    
        private void timerTick(object sender, object e)
        {
            if (cur < words.Count)
            {
                path = Dictionary.wordchecker(words[cur]);//Checks words for Animation
                pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\images\\" + path + ".gif");
                textBox1.Text = s;
                cur++;
            }
            else
            {
                timer.Stop();
            }
        }
    
 
