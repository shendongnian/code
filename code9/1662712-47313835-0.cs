           private void GenerateRegions ()
        {
            MapBox.Invalidate();
            Pen blankPen = new Pen(Color.Transparent, 3);
            Console.WriteLine(CharacterLocation);
            if (CharacterLocation == "WorldMap")
            {
                Console.WriteLine(CharacterLocation);
                Rectangle[] rects =
            {
                 Location1 = new Rectangle(64, 25, 20,  20),
                 Location2 = new Rectangle(68, 70, 20,  20)
            };
                using (var g = Graphics.FromImage(MapBox.Image))
                {
                    g.DrawRectangles(blankPen, rects);
                    MapBox.Refresh();
                }
            }
       private void MapBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Location1.Contains(e.Location))
           {
                arealbl.Text = "You clicked it 1";
            }
            if (Location2.Contains(e.Location))
            {
                arealbl.Text = "You clicked it 2";
            }
}
