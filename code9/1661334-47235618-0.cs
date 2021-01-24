    public static void Main()
    {
        string directory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
        directory = Path.Combine(directory, @"/Maps/Level1.txt"); // Better use Path.Combine for combining paths
    
        // It is enough to read the text once and not on every iteration
        string fileContent = File.ReadAllText(directory);
    
        // In your provided sample the blank sign signals a new row in the matrix
        string[] rows = fileContent.Split(' ');
                
        // Assuming that it is a matrix, which must always be the same width per line
        // NullChecks ...
        int rowLength = rows[0].Length;
        int rowCount = rows.Length;
        char[,] map = new char[rowLength, rowCount];
    
        for (int i = 0; i < rowCount; i++)
        {
            for(int j = 0; j < rowLength; j++)
            {
                map[i, j] = rows[i][j];
                Console.Write(map[i, j]);
            }
            // We are done with this row, so jump to the next line
            Console.WriteLine();
        }
    }
