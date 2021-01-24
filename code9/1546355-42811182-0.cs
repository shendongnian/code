    string myUserName = "Admin";
        string[] lines = File.ReadAllLines(usersTextFile, Encoding.UTF8);
        bool found = false;
        if (lines != null)
        {
            foreach (var l in lines)
            {
                if (string.IsNullOrEmpty(l))
                    continue;
                if (l.ToLower() == myUserName.ToLower())
                {
                    found = true;
                    break;
                }
            }
        }
        if (found)
            MessageBox.Show("Welcome " + myUserName + "!", "Protected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        else
            MessageBox.Show("User not found!", "Protected", MessageBoxButtons.OK, MessageBoxIcon.Error);
