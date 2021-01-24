    var List<double> allValues = new List<double>();
    if (RDR.HasRows)
            {
                while (RDR.Read())
                {
                   allValues.Add(Convert.ToDouble(RDR["Defects"]));
                }
            }
  
