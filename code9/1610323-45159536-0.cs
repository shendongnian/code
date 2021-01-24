    private void BtnPrint_Click(object sender, EventArgs e)
    {            
        for (int i = 0; i < persons.Count(); i++)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += 
                delegate(object o, PrintPageEventArgs e)
                {            
                    var img = System.Drawing.Image.FromFile(person[i].Pic);
                    Point loc = new Point(400, 100);
                    e.Graphics.DrawImage(img, loc);
                };
            pd.Print();
        }
    }
