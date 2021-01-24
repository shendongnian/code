            private void actionStatistics_Click(object sender, EventArgs e)
            {
                int total = 0;
    
                for (int i = 0; i < productsDataGridView.Rows.Count; i++)
                {
                    if (productsDataGridView.Rows[i].Cells[6] != null && (productsDataGridView.Rows[i].Cells[6].Value.ToString().IsNumeric()))
                    {
                        total += int.Parse(productsDataGridView.Rows[i].Cells[6].Value.ToString());
                    }
                }
    
                MessageBox.Show("Total quantity: " + total);
            }
    
        }
        public static class ExtensionMethods
        {
            public static bool IsNumeric(this string s)
            {
                float output;
                return float.TryParse(s, out output);
            }
        }
    
    
    
    
       
