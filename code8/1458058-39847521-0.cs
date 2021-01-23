      string inputString = "2,2,R1C1=211,R1C2=212,R2C1=213,R2C2=214";
      string[] splitArray = inputString.Split(',');
      int totalRows = int.Parse(splitArray[0]);
      int totalCols = int.Parse(splitArray[1]);
      int itemIndex = 2;
      
      // add the columns
      for (int i = 0; i < totalCols; i++)
      {
        dataGridView1.Columns.Add("Col", "Col");
      }
      // add the rows
      dataGridView1.Rows.Add(totalRows);
      for (int i = 0; i < totalRows; i++)
      {
        for (int j = 0; j < totalCols; j++)
        {
           dataGridView1.Rows[i].Cells[j].Value = splitArray[itemIndex];
          itemIndex++;
        }
      }
