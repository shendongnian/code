    // ...
    bool result =  await Task.Run(() => IAsyncTrue.GetBigList());
    textBox1.Text = result.ToString(); //This line will execute before the code initiated by the previous line.
    // ...
    } // end class
    public class IAsyncTrue
    {
        public static bool GetBigList()
        {
              // The first three lines are the code for checking asynchrony, you can delete them
              Stopwatch sw = new Stopwatch();
              sw.Start();
              while (1 == 1) { if (sw.ElapsedMilliseconds > 2000) break; }
              return true;
        }
    }
