        using System.IO;
        public static string GetData(string _txtfile, string searchstring)
        {
            string res = "";
            using (StreamReader rd = new StreamReader(_txtfile, true))
            {
                while (true)
                {
                    try
                    {
                        string line = rd.ReadLine().Trim();
                        if (line.Contains(searchstring))
                        {
                            return line;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            return res;
        }
