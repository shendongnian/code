    public string[] parseCSVWithQuotes(string csvLine)
        {
            string ret = "";
            string thisChar = "";
            string lastChar = "";
            bool needleDown = false;
            for(int i = 0; i < csvLine.Length; i++)
            {
                thisChar = csvLine.Substring(i, 1);
                if (thisChar == "'")
                    needleDown = needleDown == true ? false : true;
                if (thisChar == ",") {
                    if (needleDown)
                    {
                        ret += "|";
                    }else
                    {
                        ret += ",";
                    }
                }
                if (!needleDown && (thisChar == "\"" || thisChar == "*")) {//repeat for any undesired character or use RegEx
                                                                           //do not add
                }
                else
                {
                    if ((lastChar == "'" || lastChar == "\"" || lastChar == ",") && thisChar == lastChar)
                    {
                        //do not add
                    }else
                    {
                        ret += thisChar;
                        lastChar = thisChar;
                    }
                }
            }
            string[] parts = ret.Split(',');
            for(int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Replace("|", ",");
            }
            return parts;
        }
 
