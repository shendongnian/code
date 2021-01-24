    }
    public class bgcar
    {
        private Form frm;
        private List<PictureBox> wagon;
        private Random rnd = new Random();
        public bgcar(Form frm) //constructor receives the Form
        {
            this.frm = frm; // store Form reference for possible later use
            wagon = new List<PictureBox>();
            PictureBox pb = new PictureBox();
            pb.Image = new Bitmap(game.Properties.Resources.SportwagonA);
            frm.Controls.Add(pb); // add created control to both the Form and our List
            wagon.Add(pb);
            pb = new PictureBox();
            pb.Image = new Bitmap(game.Properties.Resources.SportwagonB);
            frm.Controls.Add(pb);
            wagon.Add(pb);
        }
        public void update()
        {
            foreach(PictureBox pb in wagon)
            {
                int x = rnd.Next(100);
                int y = rnd.Next(100);
                pb.Location = new Point(x, y);
            }
        }
    }
