        private void button1_Click(object sender, EventArgs e)
        {
            //to search for a file in folder
            String name_of_file = "Test";
            String search_file = @"C:\Users\User\Desktop\" + name_of_file + ".txt";
            //System.IO.File.WriteAllText("D:\\Shreyas\\sample.txt", search_file);
            //search and open the file
            if (System.IO.File.Exists(search_file))
            {
                string tmp = System.IO.File.OpenText(@"C:\Users\User\Desktop\" + name_of_file + ".txt").ReadLine();
                System.IO.File.WriteAllText(@"C:\Users\User\Desktop\Test_Write.txt", tmp);
            }
            else
            {
                Debug.WriteLine("Doesnt Exists");
            }
        }
