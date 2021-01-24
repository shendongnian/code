        static String GetUserNames(List<string> userNames)
        {
            List<string> userNamesCopy = userNames.ToList();
            string strComment = "";
            Random r = new Random();
            int userIndex;
            do
            {
                userIndex = r.Next(0, userNamesCopy.Count);
                strComment += (userNamesCopy[userIndex] + " ");
                userNamesCopy.RemoveAt(userIndex);
            }
            while (userNamesCopy.Count > 0);
            return strComment;
        }
