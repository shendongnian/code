    using (StreamReader sr = new StreamReader(path))
    {
        // Read the stream to a string, and write the string to the console.
        line = sr.ReadToEnd();
        while ((line = file.ReadLine()) != null)
        {
            if (line.Contains("Computation Time for part A Analysis ="))
            {
                txt_t_a.Text = Regex.Replace(line, @"[^0-9.]+", "");
            }
            // Remove this line. 
            // file.Close();
        }
        // Put it here
        file.Close()
    } 
    // Or here
