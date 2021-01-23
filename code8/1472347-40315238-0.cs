        static void Main(string[] args)
        {
            List<String> linesAfterFiltering = new List<String>();
            Boolean skipNextLineDueToFoundDuplicate = false;
            String curLine = null;
            using(StreamReader r = new StreamReader(args[0]))
            {
                while(null != (curLine = r.ReadLine().Trim()))
                {
                    // Check it curLine is a duplicate
                    if(linesAfterFiltering.Contains(curLine))
                    {
                        skipNextLineDueToFoundDuplicate = true;
                        continue;
                    }
                    // We have to skip one line since we found a duplicate previously
                    if(skipNextLineDueToFoundDuplicate)
                    {
                        skipNextLineDueToFoundDuplicate = false;
                        continue;
                    }
                    // We found a new value that we don't have to skip => save it
                    linesAfterFiltering.Add(curLine);
                }
            }
        }
