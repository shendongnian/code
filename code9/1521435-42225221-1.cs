    List<string> row1List = new List<string>();
        List<string> row2List = new List<string>();
        List<string> row3List = new List<string>();
        public RelayCommand<string> UpdateSelection { get; private set; }
        public MainViewModel()
        {
            UpdateSelection = new RelayCommand<string>((str) => UpdateSelectionExecute(str));
        }
 
        private void UpdateSelectionExecute(string str)
        {
            string[] split = str.Split(';');
            switch (split[0])
            {
                case "1":
                    Remove(split[1]);
                    row1List.Add(split[1]);
                    break;
                case "2":
                    Remove(split[1]);
                    row2List.Add(split[1]);
                    break;
                case "3":
                    Remove(split[1]);
                    row3List.Add(split[1]);
                    break;
            }
            OutputToConsole();
        }
        private void Remove(string character)
        {
            if (row1List.Contains(character))
            {
                row1List.Remove(character);
            }
            if (row2List.Contains(character))
            {
                row2List.Remove(character);
            }
            if (row3List.Contains(character))
            {
                row3List.Remove(character);
            }
        }  
        private void OutputToConsole()
        {
            Console.WriteLine("List 1: ");
            row1List.OrderBy(o => o).ToList().ForEach((c) => Console.Write(c));
            Console.WriteLine("");
            Console.WriteLine("List 2: ");
            row2List.OrderBy(o => o).ToList().ForEach((c) => Console.Write(c));
            Console.WriteLine("");
            Console.WriteLine("List 3: ");
            row3List.OrderBy(o => o).ToList().ForEach((c) => Console.Write(c));
            Console.WriteLine("");
        }
