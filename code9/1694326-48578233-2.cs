        public override object Convert(
                object value,
                Type targetType,
                object parameter)
        {
            int iValue;
            if (int.TryParse(value.ToString(), out iValue))
            { if (iValue == 10) return Colors.Blue; }
            return Colors.Black;  
        }
