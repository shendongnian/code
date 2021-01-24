    public void DoSomething(char symbol, Action<string> execute)
    {
        byte[] body = execute.Method.GetMethodBody().GetILAsByteArray();
        if ((body.Length == 1 && body[0] == 42) || (body.Length == 2 && body[0] == 0 && body[1] == 42))
        {
            // 0 - no op
            // 42 - return
            DoThis(...)
        }
        else
        {
            DoThat(...)
        }
    }
