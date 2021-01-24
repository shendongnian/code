    void tmrRepeatedScan_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
            try
            {
                lock (thisLock)
                {
                    var detectedTags = serialPort.Scan(true, false, true, false);
                    foreach (var tag in detectedTags)
                    {
                        bool tagFound = false;
                        string TID = Regex.Replace(Conversions.ByteToHexadecimal(tag.GetTagId()), "(.{2})(?!$)", "$0-");
                        string EPC = Regex.Replace(Conversions.ByteToHexadecimal(tag.GetEpc()), "(.{2})(?!$)", "$0-");
                        foreach (DataGridViewRow row in dgvTags.Rows)
                        {
                            if (row.Cells[0].Value.ToString().Equals(TID))
                            {
                                row.DefaultCellStyle.BackColor = Color.LightGreen;
                                tagFound = true;
                                break;
                            }
                        }
                        bool isNewTag = !tagsReaded.Contains(TID);
                        if (!tagFound && isNewTag )
                        {
                            dgvTags.BeginInvoke(new InvokeDelegate(() => AddRow(TID, EPC)));
                        }
                        if (newTag)
                        {
                            tagsReaded.Add(TID);
                        }
                    }
                }
                foreach (DataGridViewRow row in dgvTags.Rows)
                {
                    if (!tagsReaded.Contains(row.Cells[0].Value.ToString()))
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                foreach (DataGridViewRow row in dgvTags.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
    }
