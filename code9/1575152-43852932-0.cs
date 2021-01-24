            using (StreamWriter sw = new StreamWriter(fs))
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i] = new int[6];
                    for (int k = 0; k < rows[i].Length; k++)
                    {
                        columnsXs[k] = columnsXs[k] + cellSide;
                        sw.Write(" " + columnsXs[k] + " ");
                    }
                    sw.WriteLine();
                }
            }
