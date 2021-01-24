     private void DownloadXml()
        {
            try
            {
                MemoryStream stream = null;
                if (grdMessages.SelectedItems.Count > 0)
                {
                    foreach (GridDataItem item in grdMessages.SelectedItems)
                    {
                        int queueId = int.Parse(item["QueueId"].Text);
                        ibis_GetXmlTextResult result = Client.IbisGetClient(Endpoint).ibis_GetXmlText(queueId);
                        stream = new MemoryStream();
                        var r = result.XmlMessage.ToString();
                        //r = "Hello this is my file:)";
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write(r);
                            writer.Flush();
                        }
                        WriteToPage(stream.ToArray(), "text/xml; charset=UTF-8", string.Format("{0}_ClientXml.xml", queueId));
                }
            }
            catch (Exception ex)
            {
                LogException(ex, "Demand Filter", "Well that didn't work. Check for error " + ex.StackTrace);
            }
        }
