    for (int i = 0; i < row; i++)
                {
                    string content = sr.ReadLine();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var tokens = content.Split(',');
                        for (int j = 0; j < col; j++)
                        {
                            data[i, j] = tokens[j];
                        }
                    }
                    else
                    {
                        for (int j = 0; j < col; j++)
                        {
                            data[i, j] = "0";
                        }
                    }
                }
