    CrossReference
        .SelectMany(str => 
            str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(kv => { 
                    string[] pair = kv.Trim().Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    return new CrossReference { TaskType = pair[0].Trim(), Aid = long.Parse(pair[1].Trim()); 
                }
            )
        );
