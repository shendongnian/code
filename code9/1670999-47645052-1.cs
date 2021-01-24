    generator();
    private async void generator()
    {
       //(...)
    
       for (int i = 0; i < array.Length; i++)
       {
          panel1.Controls[i].Text = array[i].ToString();
          panel1.Controls[i].Refresh();
          await Task.Run(async () => await Task.Delay(1000));
    
          //(...)
    
       }
    }
