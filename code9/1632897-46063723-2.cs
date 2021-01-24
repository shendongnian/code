     public void ClickNext()
    {
       List<int> test = new List<int>();
            test.Add(0);
            test.Add(1);
            test.Add(2);
            
            int msg = test[counter%list.Count];
            MessageBox.Show(msg.ToString());
            counter++;
     }
