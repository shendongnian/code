    static void checkappend(ref StringBuilder sb, CheckBox ck)
    {
        sb.Append(ck.Content.ToString());
        sb.Append(ck.IsChecked == true ?  "is checked." : " is NOT checked.");
        sb.Append(Environment.NewLine);
    }
