    class TableOrder
    {
        private int? _tablenumber;
        public int TableNumber 
        {
            get
            {
                return _tablenumber ?? (_tablenumber=GetTableNumberFromInput());
            }
            set
            {
                _tablenumber = value;
            }
        }
        private static int GetTableNumberFromInput()
        {
            Console.Write("please enter the table number:");
            string inputtablenumber = Console.ReadLine();
            return int.Parse(inputtablenumber);
        }
        //(and so on for other member properties)
    }
