    private static string[,] columnsAndTheirNames = new string[,]
    {
        { "col1", "nam1" },
        { "col2", "nam2" },
        { "col3", "nam3" }
    };
    private void foo() {
        Console.WriteLine(columnsAndTheirNames [0, 0]); // col1
        Console.WriteLine(columnsAndTheirNames [0, 1]); // nam1
        Console.WriteLine(columnsAndTheirNames [1, 0]); // col2
        Console.WriteLine(columnsAndTheirNames [1, 1]); // nam2
    }
