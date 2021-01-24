    private void button1_Click(object sender, EventArgs e)
    {
      CheckedListBox.ObjectCollection col = chk.Items;
      List<Sample> list = new List<Sample>();
      foreach (var item in col)
      {
          list.Add(new Sample { Value = item.ToString() });
      }
    
      dgw.DataSource = list;
                
     }
