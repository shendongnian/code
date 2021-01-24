    string sOL = @"
    #
    tag1, tag with space, !@#%^, ";
    
    Regex RxOL = new Regex(@"(?ms)^\#\s+(?:\s*((?:(?!,|^\#\s+).)*?)\s*(?:,|$))+");
    Match _mOL = RxOL.Match(sOL);
    while (_mOL.Success)
    {
        CaptureCollection ccOL1 = _mOL.Groups[1].Captures;
        Console.WriteLine("-------------------------");
        for (int i = 0; i < ccOL1.Count; i++)
            Console.WriteLine("  '{0}'", ccOL1[i].Value );
        _mOL = _mOL.NextMatch();
    }
