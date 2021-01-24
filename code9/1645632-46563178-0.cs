    for (int i = 0; i < newCarAdCarDgv.SelectedRows.Count; i++)
    {
        cm[i+3] = new SqlCommand("insert into carWorkCount (c_Id,carId) value (@id,@car)", cn);
        cm[i+3].Parameters.Add("@id", id);
        cm[i+3].Parameters.Add("@car", 
          Convert.ToInt32(newCarAdCarDgv.SelectedRows[i].Cells[0].Value.ToString()));
    }
