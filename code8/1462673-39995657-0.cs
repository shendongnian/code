        Form2 obj = new Form2();
        public void button4_Click(object sender, EventArgs e)
            {
                String searchValue = "Car1";
                int amount = 0;
                 foreach (DataGridViewRow row in dataGridView1.Rows)
               {
                     if(row.Cells["Type"].Value.ToString().Equals(searchValue)
                     {
                         int amount+ = Convert.ToInt32(row.Cells["Amount"].Value.ToString())
                     }
               }   
                 
                if(amount > 0 )
               {
                  obj.Controls["TextBox1"].Text = amount.ToString();
               }
               else
               {
                 obj.Controls["TextBox1"].Text = "No car found!";  
               }          
            }
