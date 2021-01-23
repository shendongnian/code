    private void CovertFileSize(DataGridViewCellFormattingEventArgs formatting)
            {
                if (formatting.Value != null)
                {
                    try
                    {
                        long bytes;
                        bytes = Convert.ToInt64(formatting.Value);
                        string size = "0 Bytes";
    
                        //GB
                        if (bytes >= 1073741824.0)
                            size = String.Format("{0:##.##}", bytes / 1073741824.0) + " GB";
                        //MB
                        else if (bytes >= 1048576.0)
                            size = String.Format("{0:##.##}", bytes / 1048576.0) + " MB";
                        //KB
                        else if (bytes >= 1024.0)
                            size = String.Format("{0:##.##}", bytes / 1024.0) + " KB";
                        //Bytes
                        else if (bytes > 0 && bytes < 1024.0)
                            size = bytes.ToString() + " Bytes";
    
                        formatting.Value = size;
                        formatting.FormattingApplied = true;
                    }
                    catch(FormatException)
                    {
                        formatting.FormattingApplied = false;
                    }
                }
    
            }
