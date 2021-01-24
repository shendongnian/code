    //Encoding:
    string passwd = "08112000";
    int pos = 0;
    string result = string.Empty;
    foreach(char c in textBox1.Text)
    {
        result += ((char)(c - passwd[pos % passwd.Length])).ToString();
        pos++;
    }
    textBox2.Text = result;
