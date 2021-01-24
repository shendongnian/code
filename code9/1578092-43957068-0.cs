    using (FileStream stream = new FileStream(path, FileMode.Append))
    {
        string dataasstring = $"[{DateTime.Now.Hour}:{DateTime.Now.Minute}][Log]{Context.User.Username}:  {Context.Message.Content}{Environment.NewLine}"; //your data
        byte[] info = new UTF8Encoding(true).GetBytes(dataasstring);
        fs.Write(info, 0, info.Length);
    }
