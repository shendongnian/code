    namespace WindowsFormsApplication2
    {
        public class Class1    
        {    
            public event EventHandler<LoopCounterArgs> LoopInteration;
            public Class1( Form1 form )
            {
                _form1 = form;
            }
    
            public void MyMethod()
            {
                for (int j = 1; j <= 20; j++)
                {
                    LoopInteration?.Invoke(this, new LoopCounterArgs(j));
                    //Thread.Sleep(100);
                }
            }
        }
    
        // DON'T initialize this with new Form1();
        private Form1 _form1;
    }
