    Debug.WriteLine(cb1.IsChecked.ToString());
    //Debug.WriteLine(((bool)cb1.IsChecked).ToString());  // this fails on null
    if (cb1.IsChecked ?? false)
        Debug.WriteLine("cb1.IsChecked ?? false");
    if (cb1.IsChecked ?? true)
        Debug.WriteLine("cb1.IsChecked ?? true");
    if (cb1.IsChecked == true)
        Debug.WriteLine("cb1.IsChecked == true");
