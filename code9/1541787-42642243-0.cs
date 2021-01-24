        static string GetSummary(string input)
        {
            var sb = new StringBuilder();
            string prevMode = "";
            string curMode = "";
            int sameModeCount = 0;
            for (int i = 0; i <= input.Length; ++i)
            {
                if (i < input.Length)
                {
                    char c = input[i];
                    if ('a' <= c && c <= 'z' || 'A' <= c && c <= 'Z')
                    {
                        curMode = "A";
                    }
                    else if ('0' <= c && c <= '9')
                    {
                        curMode = "D";
                    }
                    else
                    {
                        curMode = "S";
                    }
                }
                else
                {
                    curMode = "";
                }
                if (curMode != prevMode && prevMode != "")
                {
                    sb.Append(prevMode);
                    sb.Append(sameModeCount);
                    sameModeCount = 0;
                }
                prevMode = curMode;
                ++sameModeCount;
            }
            return sb.ToString();
        }
