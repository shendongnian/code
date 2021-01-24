     var carList = new List<Car>()
     for(int i= 0;i<= dataGridView1.Rows-1;i++)
         {
            carList.Add(new Car
                          {
                            Id = dataGridView1.Rows[i].Cells[0].Value,
                            Brand = dataGridView1.Rows[i].Cells[1].Value,
                            Model = dataGridView1.Rows[i].Cells[2].Value,
                            Year = dataGridView1.Rows[i].Cells[3].Value,
                            Color = dataGridView1.Rows[i].Cells[4].Value
                    });
    } 
    System.Windows.Forms.Clipboard.SetDataObject(carList);
    var carListFromCB = System.Windows.Forms.Clipboard.GetDataObject().GetData(carList.GetType());
