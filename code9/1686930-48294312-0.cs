    var options = new[] { "77", "34", "12" };
    for (int i = 0; i < options.Length; i++)
    {
      int position = "770123473673412".IndexOf(options[i].ToString()); 
      MessageBox.Show(position.ToString());
    }
            
