                if (txt712.Text != "")
                {
                    string strText = txt712.Text;
                    strText = Regex.Replace(strText.Trim(),",", "");   
                    xw.WriteElementString(strText);
                }
