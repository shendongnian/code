            PictureBox CopyPic1 = new PictureBox()
            {
                Name = PicBox_Name,
                Image = Image.FromFile(@"C:\C#\...\Image\textura.jpg"),
                SizeMode = PictureBoxSizeMode.CenterImage
            };
            CopyPic1.Location = new Point(X_Location, Y_Location);
            CopyPic1.Size = new System.Drawing.Size(X_Size, Y_Size);
            CopyPic1.BackColor = PictureBox_Color;
