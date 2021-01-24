    byte[] bTemplateDataOne;
            byte[] bTemplateDataTwo;
            byte[] isoTemplateBytes;
            bool ErroFlag = false;
            int nTempltSizeOne;
            int nTempltSizeTwo;
            MMMCogentCSD200APIs csd200Obj = null;
            CSD200Wrapper wr = null; 
    private void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                int nRc = -1;
                byte[] fpRawBytes = null;
                int m_Width = 0, m_Height = 0;
                isoTemplateBytes = null;
                int nfiq = 0;
                pictCaptureImg.Image = null;
                pictCaptureImg.Refresh();
                if (true == chkbCaptureOnly.Checked)
                {
                    pbClaimed.Image = null;
                 
                    pbClaimed.Refresh();
                  
                    bTemplateDataOne = null;
                    nTempltSizeOne = -1;
                    bTemplateDataTwo = null;
                    nTempltSizeTwo = -1;
                    rbClaimed.Checked = true;
                 
                    nRc = csd200Obj.captureFP(30000, ref fpRawBytes, ref m_Width, ref m_Height);
                    if (nRc == CSD200APICodes.SUCCESS && fpRawBytes != null)
                    {
                        bmp = CreateGreyscaleBitmap(fpRawBytes, m_Width, m_Height);
                        pictCaptureImg.Image = bmp;
                        MessageBox.Show("Fingerprint Capture Successful.");
                    }
                    else if (nRc == CSD200APICodes.ERROR_TIMEOUT)
                    {
                        MessageBox.Show("Fingerprint Capture Timeout");
                    }
                    else
                    {
                        MessageBox.Show("Fingerprint Capture Failed. ErrorCode: " + nRc);
                    }
                }
                else
                {
                    nRc = csd200Obj.captureFP(30000, ref fpRawBytes, ref m_Width, ref m_Height, ref nfiq, ref isoTemplateBytes);
                    if (nRc == CSD200APICodes.SUCCESS && fpRawBytes != null)
                    {
                        bmp = CreateGreyscaleBitmap(fpRawBytes, m_Width, m_Height);
                        pictCaptureImg.Image = bmp;
                        if (rbClaimed.Checked == true)
                        {
                            pbClaimed.Image = bmp;
                            if (isoTemplateBytes != null)
                            {
                                bTemplateDataOne = isoTemplateBytes;
                                nTempltSizeOne = isoTemplateBytes.Length;
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Try Again , Some error occured");
                        }
                        MessageBox.Show("Fingerprint Capture Successful.\n NFIQ: " + nfiq);
                    }
                    else if (nRc == CSD200APICodes.ERROR_TIMEOUT)
                    {
                        MessageBox.Show("Fingerprint Capture Timeout");
                    }
                    else
                    {
                        MessageBox.Show("Fingerprint Capture Failed. ErrorCode: " + nRc);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   
    private void btnMatch_Click(object sender, EventArgs e)
        {
            
            if (bTemplateDataOne != null )
            {
                //DataTable dt = new DataTable();
                //dt.Columns.Add("value");
                //for (int i = 0; i < bTemplateDataOne.Length; i++)
                //{
                //    DataRow dr = dt.NewRow();
                //    dr["value"] = bTemplateDataOne[i];
                //    dt.Rows.Add(dr);
                //}
                bool isMatch = false;
                int matched = 0;
                int index = 0; ;
                string strAppPath = Path.GetDirectoryName(Application.ExecutablePath);
                try
                {
                    string result1 = Convert.ToBase64String(bTemplateDataOne, 0, bTemplateDataOne.Length);
                                                        
                    string connectionstring = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString.ToString();
                    SqlConnection con = new SqlConnection(connectionstring);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Biometric,Name,id from Details ", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(ds);
                    con.Close();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            bTemplateDataTwo = null;
                            bTemplateDataTwo = Convert.FromBase64String(ds.Tables[0].Rows[i][0].ToString());
                            nTempltSizeTwo = bTemplateDataTwo.Length;
                            //DataTable dt1 = new DataTable();
                            //dt1.Columns.Add("value");
                            //for (int ii = 0; ii < bTemplateDataTwo.Length; ii++)
                            //{
                            //    DataRow dr = dt1.NewRow();
                            //    dr["value"] = bTemplateDataTwo[ii];
                            //    dt1.Rows.Add(dr);
                            //}
                            isMatch = csd200Obj.matchTemplates(bTemplateDataOne, bTemplateDataTwo);
                            if (isMatch == true)
                            {
                                index = i;
                                matched++;
                            }
                        }
                        if (matched > 0)
                        {
                            string msg = "Fingers are Matched." + Environment.NewLine;
                            msg += "Welcome: " + ds.Tables[0].Rows[index]["Name"];
                            msg +="( id : " + ds.Tables[0].Rows[index]["id"] + ")" + Environment.NewLine + "matched value : " + matched;
                            MessageBox.Show(msg);
                            WriteFMRFile(nTempltSizeOne, bTemplateDataOne, strAppPath + "\\One.fmr");
                            WriteFMRFile(nTempltSizeTwo, bTemplateDataTwo, strAppPath + "\\Two.fmr");
                        }
                        else
                        {
                            MessageBox.Show("Not Matched." + Environment.NewLine + "matched value : " + matched);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no fingerprint saved in the system"+Environment.NewLine+"Register someone first .");
                    }
                }
                catch (BioSDK710Exception cgtEx)
                {
                    MessageBox.Show(cgtEx.ShowError(), "CogentBioSDK710 Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //else if(chkbCaptureOnly.Checked == true && (bTemplateDataOne == null || bTemplateDataTwo == null))
            else if (chkbCaptureOnly.Checked == true && (bTemplateDataOne == null))
            {
                MessageBox.Show("Please uncheck 'Capture Only' and recapture.", "Warning");
            }
            //else if (chkbCaptureOnly.Checked == false && (bTemplateDataOne == null || bTemplateDataTwo == null))
            else if (chkbCaptureOnly.Checked == false && (bTemplateDataOne == null))
            {
                MessageBox.Show("Please capture fingerprints.", "Warning");
            }
            
        }
