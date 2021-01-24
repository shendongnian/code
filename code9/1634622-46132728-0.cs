    public void checker()
     {
         for (int i = 0; i < dataGridView1.Rows.Count; i++)
         {
            var value = dataGridView1.Rows[i].Cells[0].Value.ToString();
            if (string.IsNullOrWhiteSpace(value))
             {
                checking = false;
                return;
             }
          }
          // If we have reached this far, then none of the cells were empty.
          checking = true;
       }
