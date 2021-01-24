    private void button4_Click(object sender, EventArgs e)
    {
        string fileA, fileB, fileC;
        fileA = textBox1.Text;
        fileB = textBox2.Text;
        fileC = "result.txt";
        // Read the alpha and beta file contents, 
        // splitting each line on the comma character
        var alphaFileContents = File.ReadAllLines(fileA).SelectMany(line => line.Split(','));
        var betaFileContents = File.ReadAllLines(fileB).SelectMany(line => line.Split(','));
        // Get all beta items where an item in alpah starts with the beta item
        var similarItems = betaFileContents
            .Where(beta => alphaFileContents.Any(alpha => alpha.StartsWith(beta)));
        // Write similar items to result.txt
        File.WriteAllText(fileC, string.Join(",", similarItems));
    }
