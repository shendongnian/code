            string[] raw_text = System.IO.File.ReadAllLines("C:\\log4.csv");
            string[] data_col = null;
            int x = 0;
            foreach (string text_line in raw_text)
            {
                //MessageBox.Show(text_line);
                data_col = text_line.Split(' ', '<', '>', '[', ']', '-', '"', ';', '(', ')', '+', ':');
                if (x == 1)
                {
                    for (int i = 0; i <= data_col.Count() - 1; i++)
                    {
                        if (i == 1)
                        {
                            my_datatable.Columns.Add(Convert.ToDateTime(data_col[i]).ToString("ddMMMyyyy"));
                        }
                        else if(i==2)
                        {
                            my_datatable.Columns.Add(Convert.ToDateTime(data_col[i]).ToString("HH:mm tt")); 
                        }
                        else
                        {
                            my_datatable.Columns.Add(data_col[i]);
                        }
                    }
                    x++;
                }
                else
                {
                    my_datatable.Rows.Add(data_col);
                }
