    try
    {
      DateTime Date1= Convert.ToDateTime(TextBox1.Text).ToString("yyyy-MM-dd HH:mm:ss");
      DateTime Date2 = Convert.ToDateTime(TextBox2.Text).ToString("yyyy-MM-dd HH:mm:ss");
      if (Date1 > Date2) 
      {
        Your Code...
      }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
