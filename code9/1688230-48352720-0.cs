      ...
      foreach (DataRow dr in Ds.Tables[0].Rows)
      {
           dr.BeginEdit();
           dr["name"] = "Ali";
           dr.EndEdit();
      }
      Ds.AcceptChanges();
