    PictureBox[] cards = Enumerable.Range(1,52)
        .Select( a => 
        { 
            var p = new PictureBox(); 
            p.Name = string.Format("PictureBox{0}", a);
            this.Controls.Add(p);
            return p;
        }).ToArray();
