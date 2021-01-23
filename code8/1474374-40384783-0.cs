                if (dataGridView.Columns[e.ColumnIndex].Name.Equals("Helped"))
            {
                if (e.Value.Equals(true))
                {
                    
                    CurrencyManager cm = (CurrencyManager)dataGridView.BindingContext[dataGridView.DataSource];
                    
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        cm.SuspendBinding();
                        dataGridView.Rows[e.RowIndex].Visible = false;
                        RemoveRecord(dataGridView.Rows[e.RowIndex].DataBoundItem as Record);
                        cm.ResumeBinding();
                    }));
                    
