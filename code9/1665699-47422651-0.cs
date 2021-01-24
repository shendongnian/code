    static void Sakiniai (string fv, string skyrikliai)
        {
            char[] skyrikliaiSak = { '.', '!', '?' };
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            string naujas = "";
            foreach (string line in lines)
            {
                naujas += line;
                naujas += " ";
            }
            string[] sakiniai = naujas.Split(skyrikliaiSak);
            for(int i = 0; i < sakiniai.Length; i++)
            {
                Console.WriteLine(sakiniai[i]);
            }
        }
