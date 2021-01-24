    var stack = new Stack<char>();
    foreach (var c in a.Reverse())
    {
        if (!char.IsDigit(c))
            break;
        stack.Push(c);
    }
    return new string(stack.ToArray());
