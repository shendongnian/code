    private void timer1_Tick(object sender, EventArgs e)
    {
        //try
        {
            timer.Stop();
            for (int i = 0; i < 10000; i++)
            {
                var row = r.Next() % 10000;
                for (int col = 1; col < 10; col++)
                {
                    var colNum = r.Next() % 55;
                    if (table != null)
                        table.Rows[row][colNum] = "hi";// r.Next().ToString();
                }
                Application.DoEvents(); //add this line
            }
            table.AcceptChanges();
            timer.Start();
        }
    }
