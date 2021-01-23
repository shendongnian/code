    enum State { NA, DOT, STR };
    HashSet<string> ok = new HashSet<string>() { "Fizz", "Buzz", "Foo", "Bar", "eeeeeeeeeo", "kjkjsh", "iousadh", "kjlsadh", "jfsfs", "sdfs" };
    List<string> matches = new List<string>();
    int len = sample.Length;
    int start = -1;
    State state = State.NA;
    for (int i = 0; i < len; ++i)
    {
        char c = sample[i];
        switch (state)
        {
            case State.NA:
                if (c == '.' || c == ',' || c == ':')
                {
                    start = i;
                    state = State.DOT;
                }
                break;
            case State.DOT:
                if (c == '.' || c == ',' || c == ':')
                {
                    start = i;
                    continue;
                }
                if (c == '!' || c == '?')
                {
                    state = State.NA;
                    continue;
                }
                state = State.STR;
                break;
            case State.STR:
                if (c == '.' || c == ',' || c == ':')
                {
                    start = i;
                    state = State.DOT;
                    continue;
                }
                if (c == '!' || c == '?')
                {
                    state = State.NA;
                    string substr = sample.Substring(start + 1, i - start - 1);
                    if (ok.Contains(substr))
                    {
                        matches.Add(substr);
                        ok.Remove(substr);
                    }
                    continue;
                }
                break;
        }
    }//30ms
