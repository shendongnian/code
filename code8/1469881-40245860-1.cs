    Double d = Convert.ToDouble("866666666.6666666666666666667");
    Debug.WriteLine(d);
    Debug.WriteLine(d.ToString("G"));
    Debug.WriteLine(d.ToString("G20"));
    Debug.WriteLine(d.ToString("R"));
    Debug.WriteLine(String.Format("{0:F20}", d));
    string s = Convert.ToString(Convert.ToDouble("866666666.6666666666666666667"));
    Debug.WriteLine(s);
