	private void makeCertificate(string name, string id, string otherDetails) //You can pass any other details as well 
	{
		System.Drawing.Image PrePrintedCertificate;
		name = name.ToUpper();
		
		string PrePrintedCertificateName = "Certificate.jpg"; //Assuming Certificate JPG File is in the bin folder
		using (FileStream stream = new FileStream(PrePrintedCertificateName, FileMode.Open, FileAccess.Read))
		{
			PrePrintedCertificate = System.Drawing.Image.FromStream(stream);
		}
		RectangleF rectf4Name = new RectangleF(655, 460, 535, 90); //rectf for Name
		RectangleF rectf4ID = new RectangleF(655, 560, 400, 40); 
		System.Drawing.Rectangle rect;
		Bitmap picEdit = new Bitmap(PrePrintedCertificate, new System.Drawing.Size(1241, 1756));
		using (Graphics g = Graphics.FromImage(picEdit))
		{
			//g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Red, 2), 662, 530, 90, 40);
			//I have used upper line to see where is my RectangleF creating on the image
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			StringFormat sf1 = new StringFormat();
			sf1.Alignment = StringAlignment.Near;
			
			//g.DrawImage(codeImage, rect); //If you wanted to draw another image on the certificate image
			g.DrawString(name, new System.Drawing.Font("Thaoma", 26, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, rectf4Name, sf);
			g.DrawString(Track.Text, new System.Drawing.Font("Thaoma", 14, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, rectf4ID, sf1);
		}
		try
		{
			if (File.Exists(id + ".jpg"))
				File.Delete(id + ".jpg");
			picEdit.Save(id + ".jpg", ImageFormat.Jpeg);
			picEdit.Dispose();
		}
		catch (Exception e)
		{
			MessageBox.Show(e.Message);
		}
	}
