        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string header = ((MyObject)values[1]).Name;
            var obs = (ObservableCollection<MyObject>)values[0];
            for (int i = obs.Count - 1; i >= 0; i--)
            {
                if (obs[i]?.Name == header)
                    obs.RemoveAt(i);
            }
            return obs;
        }
