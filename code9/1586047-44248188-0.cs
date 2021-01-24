            int prev;
            //Reads the id file to see what's previous id num
            using (StreamReader a = new StreamReader("Id.txt"))
            {
                prev = int.Parse(a.ReadLine());
            }
            //Shows one more of previous value
            MessageBox.Show((prev+1).ToString());
            //Overwrites value for future use
            using (StreamWriter b = new StreamWriter("Id.txt"))
            {
                b.Write((prev+1).ToString());
            }
