        if (!File.Exists(path)) // append only if file doesnt exist
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                for (ctrl = 0; ctrl < 5 ; ctrl++)
                {
                    sw.WriteLine(OrigProductItems[ctrl] + "\t" + OrigProductQty[ctrl] + "\t\t" + OrigProductPrice[ctrl]);
                }
            }
        }
