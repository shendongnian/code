    class Program
        {
            static void Main()
            {
                var test = new Clicker();
                test.ClickNext();
                test.ClickNext();
            }
        }
    
        class Clicker
        {
            public int Index { get; set; }
    
            public void ClickNext()
            {
                var listStr = new List<string>
                {
                    "item 1",
                    "item 2",
                    "item 3"
                };
                var next = listStr[Index];
                Index++;
                MessageBox.Show(next);
                
            }
        }
