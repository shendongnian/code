    namespace WindowsFormsApplication2
    {
        public event EventHandler<LoopCounterArgs> OnLoopInteration;
    
        public class Class1    
        {    
            public Class1( Form1 form )
            {
                _form1 = form;
            }
    
            public void MyMethod()
            {
                for (int j = 1; j <= 20; j++)
                {
                    OnLoopInteration?.Invoke(this, new LoopCounterArgs(j));
                    //Thread.Sleep(100);
                }
            }
        }
    
        // DON'T initialize this with new Form1();
        private Form1 _form1;
    }
