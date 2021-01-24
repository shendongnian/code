    Panel[] arr = new Panel[10];
    const string PanelName = "panel";
    for (int i = 0; i < arr.Length; i++)
    {
        FieldInfo pi = GetType().GetField(PanelName + i,
            BindingFlags.NonPublic | BindingFlags.Instance);
        arr[i] = ((Panel)pi.GetValue(this));
    }
