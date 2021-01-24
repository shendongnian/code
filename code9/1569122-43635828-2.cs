    void datagridview_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.ColumnIndex  == 1 && e.Value != null)
                {
                    string content = e.Value.ToString();
                    string[] line = content.Split(' ');
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
    
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
    
                    SizeF[] size = new SizeF[line.Length];
                    for (int i = 0; i < line.Length; ++i)
                    {
                        size[i] = e.Graphics.MeasureString(line[i], e.CellStyle.Font);
                    }
    
                    RectangleF rec = new RectangleF(e.CellBounds.Location, new Size(0, 0));
                    using (SolidBrush bblack = new SolidBrush(Color.Black), white = new SolidBrush(Color.White))
                    {
                        for (int i = 0; i < line.Length; ++i)
                        {
                            rec = new RectangleF(new PointF(rec.Location.X + rec.Width, rec.Location.Y), new SizeF(size[i].Width, e.CellBounds.Height));
                            if (i % 2 == 0)
                            {
                                e.Graphics.DrawString(line[i], e.CellStyle.Font, bblack,  rec, sf);
                            }
                            else
                            {
                                e.Graphics.DrawString(line[i], e.CellStyle.Font, white, rec, sf);
                            }
                        }
    
                    }
    
                    e.Handled = true;
                }
    
            }
