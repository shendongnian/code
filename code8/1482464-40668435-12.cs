    string[] RemoveComment(IEnumerable<string> loc)
    {
        string[] line = loc.ToArray();
        bool startComment = false;
        int startComPos=0;
        int endComPos=-1;
        int count = line.Length;
        string comment;
        bool mistakeComment;
        int multiCommentStart, multiCommentEnd;
        for(int i=0;i<count;i++)
        {
            if (string.IsNullOrWhiteSpace(line[i]))
                continue;
            if (line[i].Contains("//"))
            {
                mistakeComment = false;
                if(line[i].Contains("*//*"))//Case mistake /**//**/ with //
                {
                    if ((line[i].IndexOf("//") - line[i].IndexOf("*//*")) == 1)
                    {
                        mistakeComment = true;
                    }
                }
                
                if(!mistakeComment)
                {
                    comment = line[i].Substring(line[i].IndexOf("//"));
                    line[i] = line[i].Replace(comment, string.Empty);
                }
            }
            if(line[i].Contains("/*"))
            {
                startComment = true;
                startComPos = line[i].IndexOf("/*");
                endComPos = -1;
            }
            else
            {
                startComPos = 0;
            }
            if (startComment)
            {
                if(!string.IsNullOrEmpty(line[i]))
                {
                    if (line[i].Contains("*/"))
                    {
                        startComment = false;
                        endComPos = line[i].IndexOf("*/", startComPos);
                    }
                    else
                        endComPos = -1;
                    if (endComPos == -1)
                    {
                        comment = line[i].Substring(startComPos);
                        line[i] = line[i].Replace(comment, string.Empty);
                    }
                    else
                    {
                        comment = line[i].Substring(startComPos, endComPos - startComPos + 2);
                        line[i] = line[i].Replace(comment, string.Empty);
                    }
                }
            }
            if (line[i].Contains("/*"))
            while((multiCommentStart = line[i].IndexOf("/*")) >= 0 &&
                (multiCommentEnd = line[i].IndexOf("*/")) >= 0 &&
                multiCommentEnd > multiCommentStart)
            {
                comment = line[i].Substring(multiCommentStart, multiCommentEnd - multiCommentStart + 2);
                line[i] = line[i].Replace(comment, string.Empty);
            }
        }
        return line;
    }
