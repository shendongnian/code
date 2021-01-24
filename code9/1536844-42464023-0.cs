    cartesianChart1.Series = new SeriesCollection
    {
       new ColumnSeries
       {
           Title = "Therapist",
           Values =  new ChartValues<int> { 10, 50, 39, 50 }
       }
    };
       
    try
    {
       con.Open();
       myReader = cmdDB.ExecuteReader();
       while (myReader.Read())
       {
          int valuez = myReader.GetInt16("magnitude");
          cartesianChart1.Series[0].Values.Add(valuez);
       }
    }
    catch (Exception ex)
    {
       MessageBox.Show(ex.ToString());
    }
