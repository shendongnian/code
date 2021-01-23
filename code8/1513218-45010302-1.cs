    try
    {
      DateTime Date1= DateTime.ParseExact(txtBox1.Text,"dd/MM/yyyy",null);
      DateTime Date2 = DateTime.ParseExact(txtBox2.Text, "dd/MM/yyyy", null);
     
      if (Date1 > Date2) 
      {
        Your Code...
      }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
