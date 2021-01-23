    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
         string header = ((MyObject)values[1]).Name;
         var obs = (ObservableCollection<MyObject>)values[0];
         for (int i = 0; i < obs.Count; i++)
         {
             if (obs[i]?.Type?.Name != header)
                 obs.RemoveAt(i);
         }
         return obs;
    }
