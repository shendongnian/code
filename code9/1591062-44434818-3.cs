    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
     {
         int n1;
         int n2;
         if (!string.IsNullOrWhiteSpace(s.Cells[rowIterator, 1]?.Value?.ToString()) &&
             !string.IsNullOrWhiteSpace(s.Cells[rowIterator, 2]?.Value?.ToString()) &&
             int.TryParse(s.Cells[rowIterator, 1].Value.ToString(), out n1) && 
             int.TryParse(s.Cells[rowIterator, 2].Value.ToString(), out n2))
        {
          Pss.Pbr = n1;
          Pss.Amount = n2;
          Ps.Add(Pss);
        }
    }
