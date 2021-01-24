    private void button1_Click(object sender, EventArgs e)
    {
     string msg = "";
       for (var i = 1; i < 6; i++)
       {
         for (var col = 0; col < i; col++)
         {
           msg += "*";
         }
         msg += "\n";
       }
       for (var i = 5; i >= 1; i--)
         {
            for (var col = 0; col< i; col++)
            {
              msg += "*";
            }
            msg += "\n";
         }
       MessageBox.Show(msg);
    }
