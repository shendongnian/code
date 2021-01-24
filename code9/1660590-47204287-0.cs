    [STAThread]
    static void Main(string[] args)
    {
        // The program has 'using AutConnListTypeLibrary' in the header
        AutConnList connections = new AutConnList();
        connections.Refresh();
        Debug.Print(connections.Count.ToString());
    }
