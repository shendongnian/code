    Stopwatch sw = new Stopwatch();
        double tt = 2000;
    
        private void button1_Click(object sender, EventArgs e)
        {
    
            sw.Start();
            if (sw.ElapsedMilliseconds >= tt)
            {
                label1.Text = "Speed reached!";
            }
            else
            {
                sw.Stop();
                duration = 0;
            }
        }
