            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QBDQ35H; Initial Catalog=TensorFacts; Integrated Security=True");
            int counter = 0;
    
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\Imagine processing\\output.txt");
            string[] large = System.IO.File.ReadAllLines("C:\\Imagine processing\\output.txt");
            for (int i = 0; i < large.Length; i += 6)
    
            {
                Dts.Variables["User::imageName"].Value = (string)large[i];
                Dts.Variables["User::bestGuess"].Value = (string)large[i + 1];
                Dts.Variables["User::secondGuess"].Value = (string)large[i + 2];
                Dts.Variables["User::thirdGuess"].Value = (string)large[i + 3];
                Dts.Variables["User::fourthGuess"].Value = (string)large[i + 4];
                Dts.Variables["User::fifthGuess"].Value = (string)large[i + 5];
                //string line0 = large[i];
                //string line1 = large[i + 1];
                //string line2 = large[i + 2];
                //string line3 = large[i + 3];
                //string line4 = large[i + 4];
                //string line5 = large[i + 5];
                //MessageBox.Show(line0 + '\n' + line1 + '\n' + line2 + '\n' + line3 + '\n' + line4 + '\n' + line5 + '\n');
                //counter++;
            }
        }  
