    for (int i = 0; i < 100; i++)
    {
         if (token.IsCancellationRequested)
         {
             token.ThrowIfCancellationRequested();
         }
         System.Threading.Thread.Sleep(1000);
         Action act = () => textBox1.Text = Convert.ToString(i);
         textBox1.Invoke(act);
    }
