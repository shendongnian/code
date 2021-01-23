    public string[] parseCSVWithQuotes(string csvLine,int expectedNumberOfDataPoints)
        {
            string ret = "";
            string thisChar = "";
            string lastChar = "";
            bool needleDown = false;
            for(int i = 0; i < csvLine.Length; i++)
            {
                thisChar = csvLine.Substring(i, 1);
                if (thisChar == "'"&&lastChar!="'")
                    needleDown = needleDown == true ? false : true;//when needleDown = true, characters are treated literally
                if (thisChar == ","&&lastChar!=",") {
                    if (needleDown)
                    {
                        ret += "|";//convert literal comma to pipe so it doesn't cause another break on split
                    }else
                    {
                        ret += ",";//break on split is intended because the comma is outside the single quote
                    }
                }
                if (!needleDown && (thisChar == "\"" || thisChar == "*")) {//repeat for any undesired character or use RegEx
                                                                           //do not add -- this eliminates any undesired characters outside single quotes
                }
                else
                {
                    if ((lastChar == "'" || lastChar == "\"" || lastChar == ",") && thisChar == lastChar)
                    {
                        //do not add - this eliminates double characters
                    }else
                    {
                        ret += thisChar;
                        lastChar = thisChar;
                        //this character is not an undesired character, is no a double, is valid.
                    }
                }
            }
            //we've cleaned as best we can
            string[] parts = ret.Split(',');
            if(parts.Length==expectedNumberOfDataPoints){
            for(int i = 0; i < parts.Length; i++)
            {
                //go back and replace the temporary pipe with the literal comma AFTER split
                parts[i] = parts[i].Replace("|", ",");
            }
            
            return parts;
            }else{
                //save ret to bad CSV log
                return null;
            }
        }
 
