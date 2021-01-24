    public static class ArgumentLineParser
    {
        public static string[] ToArguments(string cmd)
        {
            if (string.IsNullOrWhiteSpace(cmd))
            {
                return new string[0];
            }
            var argList = new List<string>();
            var parseStack = new Stack<char>();
            bool insideLiteral = false;
            for (int i = 0; i < cmd.Length; i++)
            {
                bool isLast = i + 1 >= cmd.Length;
                if (char.IsWhiteSpace(cmd[i]) && insideLiteral)
                {
                    // Whitespace within literal is kept
                    parseStack.Push(cmd[i]);
                }
                else if (char.IsWhiteSpace(cmd[i]))
                {
                    // Whitespace delimits arguments
                    MoveArgumentToList(parseStack, argList);
                }
                else if (!isLast && '\\'.Equals(cmd[i]) && '"'.Equals(cmd[i + 1]))
                {
                    //Escaped double quote
                    parseStack.Push(cmd[i + 1]);
                    i++;
                }
                else if ('"'.Equals(cmd[i]) && !insideLiteral)
                {
                    // Begin literal
                    insideLiteral = true;
                }
                else if ('"'.Equals(cmd[i]) && insideLiteral)
                {
                    // End literal
                    insideLiteral = false;
                }
                else
                {
                    parseStack.Push(cmd[i]);
                }
            }
            MoveArgumentToList(parseStack, argList);
            return argList.ToArray();
        }
        private static void MoveArgumentToList(Stack<char> stack, List<string> list)
        {
            var arg = string.Empty;
            while (stack.Count > 0)
            {
                arg = stack.Pop() + arg;
            }
            if (arg != string.Empty)
            {
                list.Add(arg);
            }
        }
    }
