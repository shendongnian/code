        /// <summary>
        /// With return bool
        /// </summary>
        /// <returns></returns>
        public static bool UploadLog()
        {
            var didItWork = true;//here's a return value you could use. Initialize to true
            var uploader = new BackgroundWorker();
            uploader.DoWork += delegate (object sender, DoWorkEventArgs e)
            {
                Properties.Settings.Default.logUrl = "";
                Properties.Settings.Default.Save();
                System.Collections.Specialized.NameValueCollection Data = new System.Collections.Specialized.NameValueCollection();
                Data["api_paste_name"] = "RWC_Log_" + DateTime.Now.ToString() + ".log";
                Data["api_paste_expire_Date"] = "N";
                Data["api_paste_code"] = File.ReadAllText(Properties.Settings.Default.AppDataPath + @"\Logs\RWC.log");
                Data["api_dev_key"] = "017c00e3a11ee8c70499c1f4b6b933f0";
                Data["api_option"] = "paste";
                WebClient wb = Proxy.setProxy();
                try
                {
                    byte[] bytes = wb.UploadValues("http://pastebin.com/api/api_post.php", Data);
                    string response;
                    using (MemoryStream ms = new MemoryStream(bytes))
                    using (StreamReader reader = new StreamReader(ms))
                        response = reader.ReadToEnd();
                    if (response.StartsWith("Bad API request"))
                    {
                        Logging.LogMessageToFile("Failed to upload log to Pastebin: " + response);
                        e.Result = false;
                    }
                    else
                    {
                        Logging.LogMessageToFile("Logfile successfully uploaded to Pastebin: " + response);
                        Properties.Settings.Default.logUrl = response;
                        Properties.Settings.Default.Save();
                        e.Result = true;
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogMessageToFile("Error uploading logfile to Pastebin: " + ex.Message);
                    e.Result = false;
                    didItWork = false;//did not work, so set the return value accordingly
                }
            };
            uploader.RunWorkerAsync();
            return didItWork;//return the result
        }
