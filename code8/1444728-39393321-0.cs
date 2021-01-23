               char[] splits = new char[] { ',', '|', ';' };
            string[] parts;
            foreach(char splitter in splits)
            {
                parts = myString.Split(splitter);
                if (parts.Length > 0)
                {
                    break;
                }
            }
            //process parts
