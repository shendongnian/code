            string strReplace = "000100000";
            char[] chReplace = strReplace.ToCharArray();
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x <= 8; x++)
            {
                if (x == 0 || x == 3 || x == 6 || x == 9)
                {
                    sb.Append("+");
                    sb.Append(chReplace[x]);
                }
                else
                {
                    sb.Append(chReplace[x]);
                }
            }
            sb.Append("+");
            strReplace = sb.ToString();
