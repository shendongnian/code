	using (var userNameStream = File.OpenText("user.txt"))
    using (var pwdStream = File.OpenText("pwd.txt"))
    {
        while (!userNameStream.EndOfStream && !pwdStream.EndOfStream)
        {
            // your logic
            string userName = userNameStream.ReadLine();
            string pwd = pwdStream.ReadLine();
            // your logic
        }
    }
