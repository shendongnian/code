    public static Dictionary<Socket, string> _socketNames = new Dictionary<Socket, string>();
    public static string getName(this Socket socket)
    {
        return _socketNames[socket];
    }
    public static void setName(this Socket socket, string name)
    {
        _socketNames[socket] = name;
    }
