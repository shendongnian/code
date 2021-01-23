    string RowFilter="";
             int count = textBox1.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();
             label68.Text = count.ToString();
             string[] nameParts = textBox1.Text.Split(' ');
             int cnlp = 0;
                while (cnlp < nameParts.Count())
            {
                string loopcount =nameParts[cnlp];
             
              RowFilter+="'" +  loopcount + "',";
             
             
                cnlp = cnlp + 1;
            }
    
                if (RowFilter != "")
                    RowFilter = RowFilter.Substring(0, RowFilter.Length - 1);
    
                var bd = (BindingSource)dgvShopDrawings.DataSource;
                var dt = (DataTable)bd.DataSource;
                dt.DefaultView.RowFilter = string.Format("DrawingID in ({0}) or title in ({0})  or  level in ({0})", RowFilter);
                dgvShopDrawings.Refresh();
                int ShopDrawingRecordCount = dt.Rows.Count;
                SdDgvStatusCount.Text = String.Format("Records In {0} / {1} ", dgvShopDrawings.Rows.Count, ShopDrawingRecordCount);
