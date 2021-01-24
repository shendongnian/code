    private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    currencyManager1.SuspendBinding();
    
                    if (row.IsNewRow)
                        continue;
    
    
                    if (row.Cells[0].Value.ToString().ToLower().Contains(searchTextBox.Text.ToLower()) )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                       row.Visible = false;
                    }                
                    currencyManager1.ResumeBinding();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
    
            }
        }
