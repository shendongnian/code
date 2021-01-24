    Image img = Image.FromFile("gso_ltr_head.jpg");
    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
    gfx.DrawImage(img, 350, 0);
    
    Graphics g = Graphics.FromImage(img);
    g.DrawString("<<Organization Name>> in memory of: \nThe General Services Office gratefully acknowledges a contribution to  ", helvetica, new SolidBrush(Color.Black), 390, 125, form);
    g.DrawString(tx_memoriam.Text, memory, new SolidBrush(Color.Black), 350, 355, form);
    g.DrawString("From: ", helvetica, new SolidBrush(Color.Black), 325, 125, form);
    g.DrawString(tx_city.Text + ", " + tx_state.Text +  " " +  tx_zip.Text + "\n" + tx_add2.Text + "\n" + tx_add1.Text+ "\n" + tx_name.Text, helvetica, new SolidBrush(Color.Black), 275, 165, form);
    g.Dispose();
