    var image = new Bitmap(ImageBackup); // creates new instance of image with rectangles from backup
    var g = Graphics.FromImage(image); // creates graphics from image
    // in this part draw circle at specific point
    var f = Fixations[fixationIndex];
    sizeOfFixation = (int)f.Length / FIX_SIZE_COEFICIENT;
    g.FillEllipse(dotBrush, f.PosX - 1, f.PosY - 1, 3, 3);
    g.FillEllipse(brush, (f.PosX - sizeOfFixation), (f.PosY - sizeOfFixation), sizeOfFixation * 2, sizeOfFixation * 2);
    pictureBox.Image.Dispose(); // dispose old pictureBox image
    pictureBox.Image = image; // set new image
    imageOverlay = pictureBox.CreateGraphics(); // get transparent graphics overlay for pictureBox so we can draw anything else over picture (in my case highlighting rectangles over which I hover a mouse)
    g.Dispose(); // dispose used graphics
