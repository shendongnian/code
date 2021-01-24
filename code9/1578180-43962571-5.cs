    using OI = Microsoft.Office.Interop.Excel;
    ..
    private void button2_Click(object sender, EventArgs e)
    {
        string filepath = textBox1.Text.Replace(@"\", @"\\");
        OI.Application excel = new OI.Application();
        OI.Workbook wb = excel.Workbooks.Open(filepath, ReadOnly: true);
        OI.Worksheet excelsheet = wb.ActiveSheet;
        int row0 = 1;        
        int col0 = 1;
        int rowcount = 14;
        List<PointF> points = new List<PointF>();
        for (int r = 0; r < rowcount; r++)
        {
            float x = (float) Convert.ToDouble(excelsheet.Cells[row0 + r, col0].Value);
            float y = (float) Convert.ToDouble(excelsheet.Cells[row0 + r, col0+1].Value);
            points.Add(new PointF(x, y));
        }
        wb.Close(SaveChanges: false);
        int xMax = (int) points.Select(x => x.X).Max();
        int xMin = (int) points.Select(x => x.X).Min();
        int yMax = (int) points.Select(x => x.Y).Max();
        int yMin = (int) points.Select(x => x.Y).Min();
        Bitmap bmp = new Bitmap(Math.Abs(xMax - xMin), Math.Abs(yMax- yMin));
        using (Graphics Contour = Graphics.FromImage(bmp))
        {
            Contour.TranslateTransform(-xMin, -yMin);
            Contour.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.FromArgb(255, Color.Black), 1.5f)
            { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot})
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(64, 123, 234, 45)))
            {
                Contour.FillPolygon(brush, points.ToArray());
                Contour.DrawPolygon(pen, points.ToArray());
            }
        }
        pictureBox10.Image = bmp;
    }
