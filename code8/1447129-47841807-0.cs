     public static string[] local_file; // make a string array to load the file into it
     int i = 0; // index of lines 
     try 
            {
                OpenFileDialog op = new OpenFileDialog // use OpenFileDialog to choose your file
                {
                    Filter = "Combos file (*.txt)|*.txt" ;// select only text files
                }
                if (op.ShowDialog() == DialogResult.OK)
                {
                    local_file= File.ReadAllLines(op.FileName);// load all the contents of the file into the array 
                    string count = "lines = " + Convert.ToString(local_file.Length); // number of lines 
                   
                    string file_name = op.FileName; // show the file name including the path
                }
                for (i; i < local_file.Length; i++)// loop through each line 
                    {
                     // do something here remember to use local_file[i] for the lines
                    }
            }catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
