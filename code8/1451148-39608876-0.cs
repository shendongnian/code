        private void button1_Click(object sender, EventArgs e)
        {
            sw.Stop();
           
            if (sw.Elapsed.Milliseconds >= tt)
            {
                label1.Text = "Speed reached!";
            }
            else
            {
                sw.Reset();
                sw.Start();
            }
        }
