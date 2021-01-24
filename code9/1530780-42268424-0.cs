    class MyService
    {
      public int CalculateMandelbrot()
      {
        // Tons of work to do in here!
        for (int i = 0; i != 10000000; ++i)
          ;
        return 42;
      }
    }
    
    ...
    
    private async void MyButton_Click(object sender, EventArgs e)
    {
      await Task.Run(() => myService.CalculateMandelbrot());
    }
