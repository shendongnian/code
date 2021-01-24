    List<Color> allColours = typeof(Color).GetProperties(
                         System.Reflection.BindingFlags.Static | 
                         System.Reflection.BindingFlags.Public)
                        .Select(x => (Color)x.GetValue(null)).ToList();
    comboBox_Colour.DataSource = allColours;
