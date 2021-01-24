    textBox1.Text = TurnString((18700).ToString("#,###", nfi));
    public static string TurnString(string value)
    {
        Stack<string> stack = new Stack<string>();
        foreach(string a in value.Split(' '))
        {
            stack.Push(a);
        }
        string result = string.Empty;
        while(stack.Count>0)
        {
            result += stack.Pop()+' ';
        }
        return result;
    }
