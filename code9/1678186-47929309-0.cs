        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    addItems(DataCollection);
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
        }
        public void addItems(AutoCompleteStringCollection col)
        {
            var selectedColumn = dataGridView1.CurrentCell.ColumnIndex;
            List<string> headerList = new List<string>();
            foreach (DataRow row in aSH_ORDER_DBDataSet.ASH_PROD_ORDERS.Rows)
            {
                headerList.Add(row[selectedColumn].ToString());
            }
            List<string> cleanHeaderList = headerList.Distinct().ToList();
            foreach (var item in cleanHeaderList)
            {
                col.Add(item);
            }
        }
