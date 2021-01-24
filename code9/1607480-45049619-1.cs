    using System.Windows.Forms;
    string temp = "Hi!";
    Object[] arr = new Object[] { button1, checkBox1, temp };
    foreach(Object a in arr)
    {
        if (a is button)
            MessageBox.Show(((Button)a).Name);
        else if (a is CheckBox)
            MessageBox.Show(((CheckBox)a).Name);
        else if (a is String)
            MessageBox.Show(((String)a));
    }
