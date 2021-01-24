        public string Write2CSV(System.Data.DataSet ExlDs)
        {
            using (ExlDs)
            {
                string strfilename;
                var Rnd = new Random();
                var dRandomNo = Rnd.Next(1) * 10000;
                var sAppPath = System.AppDomain.CurrentDomain.BaseDirectory;
                var sFile = @"RepFile\Dispatch" + DateTime.Now.ToString("ddMMyyyyHHmmss") + dRandomNo + ".csv";
                var sOpnURL = string.Empty;
                //TextBox1.Text = sFile
                strfilename = sAppPath + @"Reports\" + sFile;
                StreamWriter swObj = null;
                try
                {
                    swObj = File.AppendText(strfilename);
                    foreach (System.Data.DataColumn colObj in ExlDs.Tables[0].Columns)
                    {
                        swObj.Write(colObj.ColumnName + ",");
                    }
                    swObj.WriteLine();
                    for (int intRow = 0; intRow < ExlDs.Tables[0].Rows.Count - 1; intRow++)
                    {
                        for (int intCol = 0; intCol < ExlDs.Tables[0].Columns.Count - 1; intCol++)
                        {
                            swObj.Write(ExlDs.Tables[0].Rows[intRow][intCol] + ",");
                        }
                    }
                    var strFileUrl = Strings.Split(sFile, "\\");
                    sOpnURL = "RepFile/" + strFileUrl[strFileUrl.Length];
                    //sbObj.Save(strfilename);
                }
                catch (Exception ex)
                {
                    //bError = true;
                    var ErrContext = HttpContext.Current;
                    ErrContext.Items.Add("ErrDesc", ex.Message);
                    ErrContext.Items.Add("ErrSrc", ex.Source);
                    ErrContext.Items.Add("ErrInfo", ex.StackTrace);
                    ErrContext.Items.Add("ErrFile", "T");
                }
                finally
                {
                    //sbObj = null;
                    swObj.Close();
                    swObj = null;
                }
                return sOpnURL;
            }
        }
