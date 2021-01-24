    private void button4_Click(object sender, EventArgs e)
    {
        string fileA, fileB, fileC;
        fileA = textBox1.Text;
        fileB = textBox2.Text;
        fileC = "result.txt";
            // Read the alpha file contents into a list
            var alphaFileContents = File.ReadAllLines(fileA);
            // Read each line of the beta file, and select the first part
            // (up to the first comma) into a list
            var betaFilePrefixes = File.ReadAllLines(fileB)
                .Select(line => line.Split(',')[0]);
            // Get all alpha lines that start with an item in the beta list
            var similarItems = alphaFileContents
                .Where(alpha => betaFilePrefixes.Any(alpha.StartsWith));
            // Write the lines to our result file
            File.WriteAllLines(fileC, similarItems);
    }
