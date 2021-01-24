    string selectMessage(string[] messages,ref bool[] status)
    {
        for (int i = 0; i <= status.Length-1; i++) {
            if (status[i] == false) {
                status[i] = true;
                return messages[i];
            }
        }
        return "Is everything ok?";
    }
