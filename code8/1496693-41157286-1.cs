        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow newRow = stockData.Product.NewProductRow();
            using (var addForm = new Form2(newRow, true))
            {
                addForm.StartPosition = FormStartPosition.CenterParent;
                
                addForm.ShowDialog(this);
                // Here you could access any public method in Form2 
                // You could check addForm.DialogResult for the status
            }
        
        }
