       for (int i = 0; i < anzahl; i++)
       {
          pictureboxes[i].Location = new System.Drawing.Point(80 + i * 100, 40);
          pictureboxes[i].Name = "pictureBox" + i;
          pictureboxes[i].SizeMode = PictureBoxSizeMode.Zoom;
          pictureboxes[i].Size = new System.Drawing.Size(300, 300);
                    pictureboxes[i].Image = ByteArrayToImage((byte[])(rdr.GetValue("image")));
          panel1.Controls.Add(pictureboxes[i]);
          //rdr.NextResult();
       }
