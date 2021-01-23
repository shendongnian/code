    private async Task blind(string[] files)
    {
            // Generate an integer key and permute it
            int[] key = Enumerable.Range(1, files.Length).ToArray();
            Random rnd = new Random();
            int[] permutedKey = key.OrderBy(x => rnd.Next()).ToArray();
            // Loop through all the files
            for (int i = 0; i < files.Length; i++)
            {
                // Copy original file into blinding folder and rename
                // Notice, this will wait for the Task to actually complete
                await Task.Run(() => File.Copy(@"C:\test\" + files[i], @"C:\test\blind\" + permutedKey[i] + Path.GetExtension(@"C:\test\" + files[i])));
                someProgressBar.PerformStep(); // Or just set value by yourself
            }            
            // Show completed result
            MessageBox.Show("Operation complete!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
