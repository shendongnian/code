        public List<String> GetFormPermutations(List<ExtraField> inList)
        {
            List<String> retList = new List<String>();
            int[] listIndexes = new int[inList.Count];
            for (int i = 0; i < listIndexes.Length; i++)
                listIndexes[i] = 0;
            while (listIndexes[inList.Count-1] < inList.ElementAt(inList.Count-1).Options.Count)
            {
                String cString = "";
                //after this loop is complete. a line is done.
                for (int i = 0; i < inList.Count; i++) {
                    String key = inList.ElementAt(i).Name;
                    Dictionary<String, String> cOptions = inList.ElementAt(i).Options;
                    String value = cOptions.ElementAt(listIndexes[i]).Value;
                    cString += key + "=" + value;
                    if (i < inList.Count - 1)
                        cString += "|";
                }
                retList.Add(cString);
                listIndexes[0]++;
                for(int i = 0; i < inList.Count -1; i++)
                {
                    if (listIndexes[i] >= inList.ElementAt(i).Options.Count)
                    {
                        listIndexes[i] = 0;
                        listIndexes[i + 1]++;
                    }
                }
            }
            return retList;
        }
