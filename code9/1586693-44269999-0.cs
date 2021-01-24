    StringBuilder sb = new StringBuilder();
                sb.Append("\"[");
                for (int i = 0; i < arrayTesting.Length; i++)
                {
                    string item = arrayTesting[i];
    
                    sb.Append("\"");
                    sb.Append(item);
                    if (i == arrayTesting.Length - 1)
                    {
                        sb.Append("\"]");
                    }
                    else
                        sb.Append("\",");
                }
                Console.WriteLine(sb);
