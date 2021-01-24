            try
            {
                DataTable dtx = new DataTable();
                dtx.Columns.Add("amen");
                dtx.Rows.Add(new Object[] { 1 });
                dtx.Rows.Add(new Object[] { 2 });
                dtx.Rows.Add(new Object[] { 3 });
                dtx.Rows.Add(new Object[] { 4 });
                dtx.Rows.Add(new Object[] { 5 });
                dtx.Rows.Add(new Object[] { 6 });
                dtx.Rows.Add(new Object[] { 7 });
                if (dtx.Rows.Count > 0)
                {
                    Console.WriteLine(@"<ul class='col-md-6'>");
                    int c = 0;
                    int currentRow = 0;
                    foreach (DataRow dr in dtx.Rows)
                    {
                        if (c >= ((dtx.Rows.Count / 2) + (dtx.Rows.Count % 2)))
                        {
                            Console.WriteLine(@"</ul><ul class='col-md-6'>");
                            c = 0;
                            for (int i = currentRow; i < dtx.Rows.Count; i++)
                            {
                                Console.WriteLine("<li class='enabled'>" + dtx.Rows[i]["amen"].ToString() + "</li>");
                                c++;
                            }
                            Console.WriteLine(@"</ul>");
                            break;
                        }
                        Console.WriteLine("<li class='enabled'>" + dr["amen"].ToString() + "</li>");
                        currentRow++;
                        c++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
