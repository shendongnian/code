                        try
                    {
                        //SqlConnection conn = new SqlConnection(@"C:\USERS\OZ\DOCUMENTS\VISUAL STUDIO 2017\PROJECTS\SHILOV\SHILOV\LOCALDBSHILOV.MDF");
                         SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;
                            AttachDbFilename=C:\USERS\OZ\DOCUMENTS\VISUAL STUDIO 2017\PROJECTS\SHILOVI2R\SHILOVI2R\PHONENUM.MDF;
                            Integrated Security=True;
                            Connect Timeout=30;
                            User Instance=True");
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("insert into phonebook(שם,עיר,כתובת,מספר טלפון,אזור,מספר זיהוי,מחוז,נפה,דת)VALUES('" + rows[0] + "','" + rows[1] + "','" + rows[2] + "','" + rows[3] + "','" + rows[4] + "','" + rows[5] + "','" + rows[6] + "','" + rows[7] + "','" + rows[8] + "') ", conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("middle2", "SHILOVI2R", MessageBoxButtons.OK);
                        Console.WriteLine("Inserting Data Successfully");
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("dont_work", "SHILOVI2R", MessageBoxButtons.OK);
                        Console.WriteLine("Exception Occre while creating table:" + e.Message + "\t" + e.GetType());
                    }
