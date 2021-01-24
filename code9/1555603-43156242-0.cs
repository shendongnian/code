     public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        var times = Row.timespan.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
        if (times.Length > 1)
        {
            Row.begin = times[0];
            Row.end = times[1];
        }   
    }
