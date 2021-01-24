    public static class ocSAFlags
    {
        static private ObservableCollection<flag> oCFlag = getSAFlags();
        private static ObservableCollection<flag> getSAFlags()
        {
            var x = new ObservableCollection<flag>();
            var sa = new SALinqDataContext();
            var flags = sa.flags.Where(f => f.available == true)
                            .OrderBy(f => f.flag_desc);
            foreach (flag f in flags) x.Add(f);
            return x;
        }
        public static ObservableCollection<flag> OCFlag
        {
            get
            {
                return oCFlag;
            }     
        }
    }
