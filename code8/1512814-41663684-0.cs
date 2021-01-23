    private async void timer1_Tick(object sender, EventArgs e) {
        timer1.Stop();
        for (int i = 1; i < 2500; i++) {
            await Task.Delay(500); // Thread.Sleep blocks the program
            PictureBox pb = new PictureBox();
            pb.Image = Properties.Resources.chikoon;
            pb.Visible = false; // set it to true only after you've positioned the PictureBox
            this.Controls.Add(pb); // otherwise it will appear at (0, 0) and then move to a new location
            Random r = new Random();
            int xB = r.Next(0, 1920);
            int yB = r.Next(0, 1080);
            pb.Location = new Point(xB, yB);
            pb.Visible = true;
            MessageBox.Show(xB.ToString() + ", " + yB.ToString());
        }
            
    }
