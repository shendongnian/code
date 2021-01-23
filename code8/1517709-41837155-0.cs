    public static void getColumnAverages(string filePath)
    {
        // Differs from the current implementation, reads a file in as text and
        // splits by a defined delim into an array
        var filePaths = @"C:\test.csv";
        var csvArray = File.ReadLines(filePaths).Select(x => x.Split(',')).ToArray();
        // Differs from the current implementation
        var col = csvArray[0].Length;
        var row = csvArray.Length;
        // Update variables to use doubles
        double[] count = new double[col];
        double[] sum = new double[col];
        double[] average = new double[col];
        Console.WriteLine("Started");
        for (int i = 1; i < row; i++)
        {
            for (int j = 1; j < col; j++)
            {
                // Remove the quotes from your array
                var current = csvArray[i][j].Replace("\"", "");
                // Added the Method IsNullOrWhiteSpace
                if (!string.IsNullOrWhiteSpace(current))
                {
                    // Parse as double not int to account for dec. values
                    sum[j] += double.Parse(current);
                    count[j]++;
                }
            }
        }
        for (int i = 0; i < average.Length; i++)
        {
            average[i] = (sum[i] + 0.0) / count[i];
        }
        foreach (double d in average)
        {
            System.Diagnostics.Debug.Write(d + "\n");
        }
    }
