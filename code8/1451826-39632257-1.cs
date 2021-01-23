            int count = textBox1.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();
            label68.Text = count.ToString();
            string[] nameParts = textBox1.Text.Split(' ');
            int cnlp = 1;
            string rowfilter = "";
            while (cnlp <= count)
            {
                string loopcount = nameParts[(cnlp - 1)];
                lbtest5.Text = loopcount.ToString();
                if (rowfilter.Length > 0) rowfilter += " AND ";
                rowfilter += tring.Format("(DrawingID like '%{0}%' or title like '%{0}%' or level like '%{0}%')", lbtest5.Text.Replace("'", "''"));
                cnlp = cnlp + 1;
            }
            var bd = (BindingSource)dgvShopDrawings.DataSource;
            var dt = (DataTable)bd.DataSource;
            dt.DefaultView.RowFilter = rowfilter;
            dgvShopDrawings.Refresh();
            ShopDrawingRecordCount = dt.Rows.Count;
            SdDgvStatusCount.Text = String.Format("Records In {0} / {1} ", dgvShopDrawings.Rows.Count, ShopDrawingRecordCount);
