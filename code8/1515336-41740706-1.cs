        public int loginCheck() {
            //-----------------------------------------------------------------
            string[] users = File.ReadLines("Username_Passwords").ToArray();
            //line of text file added to array 
            //-----------------------------------------------------------------
            for (int i = 0; i < users.Length; i++) {
                string[] usernameAndPassword = users[i].Split('_');
                //usernames and passwords separated by '_' in file, split into two strings
                if (_username == usernameAndPassword[0] && _password == usernameAndPassword[1]) {
                    return 1;
                    //return 1, could have used bool
                }
            }
            return 0;
        }
