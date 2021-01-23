    public MyCmd : ICommand
    {
 
        public void Execute(object parameter)
        {
            string path = (string) parameter;
            //Open the path via explorer
        }
    }
