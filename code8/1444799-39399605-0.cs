    public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
    {
        string key = value as string;
        switch (key)
        {
            case "1":
                return SomethingStatic.TeacherList1;
            case "2":
                return SomethingStatic.TeacherList2;
            ...
        }
    }
