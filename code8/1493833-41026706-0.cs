     private  void Test_Click(object sender, RoutedEventArgs e)
            {
                test();
                
             }
    
            public async void test()
            {
                decimal current = 0;
                List<string> lst = new List<string>();
    
                lst.Add("Foo");
                lst.Add("Foo");
                lst.Add("Foo");
                lst.Add("Foo");
    
               decimal max = 10000;
              
              //Remove await (and async from signature) if, want to see the message box rightway.  
               await Task.Run(() => Parallel.ForEach(lst, (data) =>
                {
                    for (int i = 0; i < max; i++)
                    {                                        
                        current = current + 1;                    
                        Dispatcher.Invoke(new Action(() => LoadProgress.Value = (double)(current / max) * 100));
                    }
                }));
           
                MessageBox.Show("Done!");
            }
