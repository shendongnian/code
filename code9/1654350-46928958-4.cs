	int x = 100, y = 100; //start position
	
	Image newImage = Image.FromFile("logo.png");
	int width = 80, height = 50;
	int ix = x, iy = y; //image position
	e.Graphics.DrawImage(newImage, ix, iy, width, height);
	x += 0; //left align texts with logo image
	y += height + 30; //some space below logo
	var header = new Font("Calibri", 21, FontStyle.Bold);
	int hdy = header.GetHeight(e.Graphics); //30; //line height spacing
	var fnt = new Font("Times new Roman", 14, FontStyle.Bold);
	int dy = fnt.GetHeight(e.Graphics); //20; //line height spacing
	e.Graphics.DrawString("Visitor GatePass™", header, Brushes.Black, new PointF(x, y)); y += hdy;
	e.Graphics.DrawString("Unique Number : " + uniqueNum.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
	e.Graphics.DrawString("Full Name : " + fullname.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
	e.Graphics.DrawString("Method of Identification : " + id_method.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
	e.Graphics.DrawString("Ward Name : " + ward_name.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
	e.Graphics.DrawString("Ward Class : " + ward_class.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
	e.Graphics.DrawString("Ward House : " + ward_house.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
	e.Graphics.DrawString("House Master : " + house_master.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
	e.Graphics.DrawString("Accompanying People : " + no_accPeople.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
