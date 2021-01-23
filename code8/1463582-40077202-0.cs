    string Game_option_values = Score.Value.ToString();
    string newpath = path + ".bak"; 
    File.Copy(path, newpath); // copy to new file
    using (StreamReader sr = new StreamReader(newpath)) // open the new file
    using (StreamWriter sw = new StreamWriter(path, false)) // overwrite the original file
    {
        while(!sr.EndOfStream)
        {
            string line = sr.ReadLine(); // read per line, so it does not consume memory too much
            line = line.Replace("score_value", Game_option_values); // replace the string with the value from Form
            sw.WriteLine(line); // write per line
        }
    }
    // Then you can delete the new file
