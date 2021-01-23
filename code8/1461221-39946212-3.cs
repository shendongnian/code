    public class SubItem : BindableBase
    {
        private string _part1;
        public string Part1
        {
            get
            {
                return _part1;
            }
            set
            {
                _part1 = value;
                OnPropertyChanged("Part1");
            }
        }
        private string _part2;
        public string Part2
        {
            get
            {
                return _part2;
            }
            set
            {
                _part2 = value;
                OnPropertyChanged("Part2");
            }
        }
    }
