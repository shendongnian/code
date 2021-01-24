        pictureBox1.Image = Image.FromFile(someImageFile);
        // read the orientation:
        PropertyItem pi = getPropertyItemByID(pictureBox1.Image , 0x0112);  
        if (pi != null)
        {
            byte o = pi.Value[0];
            if (o!= 1)
            {
                Bitmap bmp2 = (Bitmap)pictureBox1.Image.Clone();
                if (o==2) bmp2.RotateFlip(RotateFlipType.RotateNoneFlipX);  //**
                if (o==3) bmp2.RotateFlip(RotateFlipType.RotateNoneFlipXY); //**
                if (o==4) bmp2.RotateFlip(RotateFlipType.RotateNoneFlipY);  //**
                if (o==5) bmp2.RotateFlip(RotateFlipType.Rotate90FlipX);    //**
                if (o==6) bmp2.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (o==7) bmp2.RotateFlip(RotateFlipType.Rotate90FlipXY);   //**
                if (o==8) bmp2.RotateFlip(RotateFlipType.Rotate90FlipY);    //**
                pictureBox2.Image = bmp2;
            }
        }
