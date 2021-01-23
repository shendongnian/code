    private void clipboardBtn_Click(object sender, EventArgs e)
    {
                string YourGetClipBoardTextString = "aaa;bbb;ccc;ddd";
                List<string> _items = new List<string>();
                _items.AddRange(YourGetClipBoardTextString.Split(';').ToArray()); // you can split the string by any char seperator ";" " ", "," etc...
    }
