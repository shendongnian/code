        public Brush Color
        {
            get
            {
                return name.Length > 0 && name[0] == 'D' ? Brushes.Red : Brushes.Black;
            }
        }
