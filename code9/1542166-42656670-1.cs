        private void dataGridView1_CellPainting(object sender, 
                                                DataGridViewCellPaintingEventArgs e)
        {
            Rectangle cr = e.CellBounds;
            e.PaintBackground(cr, true);  //  (2)
            e.PaintContent(cr);           //  (3)
            if (e.ColumnIndex % 2 == 0)
            {
                    e.Graphics.DrawLine(Pens.LawnGreen, cr.Right-2, cr.Top + 1, 
                                                        cr.Right-12, cr.Bottom - 2);
            }
            e.Handled = true;  // (1)
        }
