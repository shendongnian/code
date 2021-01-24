    using System.Text.RegularExpressions;
    string[] getRowArr = Regex.Split(getRow, "'");
    foreach (string item in getRowArr)
    {
        if (item.ToLower().Contains(".aspx") || item.ToLower().Contains(".com"))
        {
            Label1.Text += item + "<br />";
        }
    }
