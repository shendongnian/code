    public static class StringToListOfJsonStrings
    {
        public static List<string> ToJsons(this string jsonsString)
        {
            List<string> jsons = new List<string>();
            Stack stack = new Stack();
            int index = 0;
            foreach (char character in jsonsString)
            {
                if (character == '{') 
                    stack.Push('{'); 
                else if (character == '}') 
                    stack.Pop(); 
                if (stack.Count == 0)
                {
                    jsons.Add(jsonsString.Substring(0, ++index));
                    jsonsString = jsonsString.Substring(index);
                    index = 0;
                }
                else index++;
            }
            return jsons;
        }
    }
