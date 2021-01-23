    List<PictureBox> boxes = new List<PictureBox>();
    pictureBox0.Image = Properties.Resources.dog0;
    pictureBox1.Image = Properties.Resources.dog1;
    pictureBox2.Image = Properties.Resources.dog2;
    pictureBox3.Image = Properties.Resources.dog3;
    boxes.Add(pictureBox0);
    boxes.Add(pictureBox1);
    boxes.Add(pictureBox2);
    boxes.Add(pictureBox3);
    boxes.OrderBy(a => Guid.NewGuid()); // Dirty but effective shuffle method
