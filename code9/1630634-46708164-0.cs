       SqlDataAdapter sc3 = new SqlDataAdapter("select KeyboardName from  dbo.Keyboards", SqlConnection);
            DataTable dt3 = new DataTable();
            sc3.Fill(dt3);
            int keyboardRows = 0;
            if (dt3.Rows.Count % 2 == 0)
            {
                keyboardRows = dt3.Rows.Count / 2;
            }
            else
            {
                keyboardRows = (dt3.Rows.Count / 2) + 1;
            }
            KeyboardButton[][] kbc = new KeyboardButton[(keyboardRows + 1)][];
            KeyboardButton[] keys = new KeyboardButton[dt3.Rows.Count];
            var i = 0;
            foreach (DataRow cn3 in dt3.Rows)
            {
                keys[i] = new KeyboardButton(cn3["KeyboardName"].ToString());
                i++;
            }
            for (int r = 0, s = 0; r < keyboardRows; r++, s++)
            {
                if (dt3.Rows.Count % 2 == 0)
                {
                    kbc[r] = new KeyboardButton[] {keys[r + s], keys[r + s + 1]};
                }
                else
                {
                    if ((r + s) != keys.Length)
                    {
                        kbc[r] = new KeyboardButton[] { keys[r + s], keys[r + s + 1] };
                    }
                    else
                    {
                        kbc[r] = new KeyboardButton[] { keys[r + s] };
                    }
                }
            }
            kbc[keyboardRows] = new KeyboardButton[] { new KeyboardButton("Return to Main Menu"), };
            calendarMenu = new ReplyKeyboardMarkup
            {
                Keyboard = kbc
            };
