      long openingBalace = 5000;
      for (int i = 0; i < GridView1.Rows.Count; i++)
      {
          string input = GridView1.Rows[i].Cells[7].Text;
          if (Regex.IsMatch(input, @"^\d+$"))
          {
               long sum = openingBalace + Convert.ToInt64(input);
               GridView1.Rows[i].Cells[8].Text = sum.ToString();
          }
       }
