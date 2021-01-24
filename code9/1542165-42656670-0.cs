        private void dataGridView1_CellPainting(object sender, 
                                                DataGridViewCellPaintingEventArgs e)
        {
            Rectangle cr = e.CellBounds;
            e.PaintBackground(cr, true);
            e.PaintContent(cr);
            if (e.ColumnIndex % 2 == 0)
            {
                    e.Graphics.DrawLine(Pens.LawnGreen, cr.Right-2, cr.Top + 1, 
                                                        cr.Right-12, cr.Bottom - 2);
            }
            e.Handled = true;
        }
