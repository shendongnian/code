            string[] toReplace = { "\"", " " };
            string[] with = { "\\\"", "\\r\\n\\r\\n" };
            string str = "Here is the list: \"Pizza\" \"Eggs\"";
            string toCheck = str.Substring(str.LastIndexOf(':') + 2);
            Console.Write(str + "\n");
            for (int i= 0; i < toReplace.Length; i++)
            {
                toCheck = toCheck.Replace(toReplace[i], with[i]);
            }
            Console.Write(toCheck + "\n");
