    public List<Karta> insertInList()
    {
         foreach (DataGridViewRow row in dataGridView1.Rows)
         {
               
                    Card k = new Card();
                    k.Id =(int)row.Cells[0].Value;
                    k.Word =(string) row.Cells[1].Value;
                    k.Description = (string)row.Cells[2].Value;
                    List.Add(k);
                  
               
         }
     return List;
    }
