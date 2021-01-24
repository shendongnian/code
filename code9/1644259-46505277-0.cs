    private void btnMakeCalc_Click(object sender, EventArgs e)
    {
        Point[] pts = new Point[] { new Point { X = -100, Y = 0 }, new Point { X = 0, Y = 0 } };
        for (int i = 0; i < pts.Count(); i++)
        {
            float X1value = pts[i].X;
            //The below line throws the error (see fix)
            if (i != 0)
                float X2value = pts[i-1].X;
                MessageBox.Show("X1 Is: " + Convert.ToString(pts[i].X) + "Environment.NewLine" + "X2 Is: " + Convert.ToString(pts[i-1].X));
            else
              continue;
        }
    }
