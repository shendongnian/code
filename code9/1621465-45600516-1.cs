     private void comboBox1_TextChanged(object sender, EventArgs e)
     { 
        string rex=comboBox1.Text;
        Regex regex = new Regex(@"^\d$");
        
        if (regex.IsMatch(compare))
        { 
          rex= Regex.Replace(rex, @"(?<=\d),(?=\d)|[.]+(?=,)[A-Z]", "");
        }
        comboBox1.Text=rex;
      }
