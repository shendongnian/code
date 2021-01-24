    using (StreamReader sr = new StreamReader(path))
                {
                    // Read the stream to a string, and write the string to the console.
                    line = sr.ReadToEnd();
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("Computation Time for part A Analysis ="))
                        {
    
                            txt_t_a.Text = Regex.Replace(line, @"[^0-9.]+", "");
    
                        }
    
                        sr.Close();
                    }
                }
