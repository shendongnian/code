    public bool _MCheckWindowsLogin()
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=True;database=master"))
                {
                    try
                    {
                        con.Open();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
    
            public bool _MCheckSQLLogin()
            {
                using (SqlConnection con = new SqlConnection("ConnectionStringWithSQLLogIN"))
                {
                    try
                    {
                        con.Open();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
    
            public bool _MCheckLogin()
            {
                if (!_MCheckSQLLogin())
                {
                    if (!_MCheckWindowsLogin())
                    {
                       MessageBox.Show ("Some Error Message Here");
                        return false;
                    }
                    using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=True;database=master"))
                    {
                        con.Open();
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("DECLARE @D BIGINT IF NOT EXISTS (SELECT NAME FROM [master].[sys].[syslogins] WHERE name = 'YourLoginName') BEGIN SET @D = 1 END SELECT @D", con))
                            {
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    if (dr.HasRows)
                                    {
                                        while (dr.Read())
                                        {
                                            bool a = Convert.ToBoolean(dr[0]);
                                            dr.Close();
                                            if (a)
                                            {
                                                string Aa = @"EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'LoginMode', REG_DWORD, 2 ;";
                                                Aa += "CREATE LOGIN [YourLoginName] WITH PASSWORD=N'YourPassword', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF ;";
                                                Aa += "EXEC master..sp_addsrvrolemember @loginame = N'YourLoginName', @rolename = N'bulkadmin' ;";
                                                Aa += "EXEC master..sp_addsrvrolemember @loginame = N'YourLoginName', @rolename = N'dbcreator' ;";
                                                Aa += "EXEC master..sp_addsrvrolemember @loginame = N'YourLoginName', @rolename = N'diskadmin' ;";
                                                Aa += "EXEC master..sp_addsrvrolemember @loginame = N'YourLoginName', @rolename = N'processadmin' ;";
                                                Aa += "EXEC master..sp_addsrvrolemember @loginame = N'YourLoginName', @rolename = N'securityadmin' ;";
                                                Aa += "EXEC master..sp_addsrvrolemember @loginame = N'YourLoginName', @rolename = N'serveradmin' ;";
                                                Aa += "EXEC master..sp_addsrvrolemember @loginame = N'YourLoginName', @rolename = N'sysadmin' ;";
                                                using (SqlCommand cmd8 = new SqlCommand(Aa, con))
                                                {
                                                    cmd8.ExecuteNonQuery();
                                                }
                                            }
                                            con.Close();
                                            Thread.Sleep(2000);
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception exp)
                        {
                            con.Close();
                            MessageBox.Show(exp.Message);
                            return false;
                        }
                    }
                }
                return true;
            }
