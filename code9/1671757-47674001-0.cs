                else
                {
                    string leftColumn = oStreamDataValues[0];
                    for (int i = 1; i < oStreamDataValues.Length; i++)
                    {
                        string middleColumn = headerNames[i];
                        string rightColumn = oStreamDataValues[i];
                        string newRow = string.Join(";", leftColumn, middleColumn, rightColumn, Environment.NewLine);
                        File.AppendAllText(path, newRow);
                    }
                }
