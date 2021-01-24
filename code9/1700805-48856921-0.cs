    private void labelPineapple_Click(object sender, EventArgs e)
    {
       if (!My_Pizza.Items.Contains(pineapple))
       {
          My_Pizza.Items.Add(pineapple);
          labelPineapple.BackColor = Color.Green;
          _oldValue = pineapple;
       }
       else
       {
          My_Pizza.Items.Remove(pineapple);
       }
    }
