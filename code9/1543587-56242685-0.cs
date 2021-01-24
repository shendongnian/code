                string configPathBackup;
                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                    configPathBackup = config.FilePath + ".bak";
                    config.SaveAs(configPathBackup, ConfigurationSaveMode.Full, true);
                }
                catch (ConfigurationErrorsException ex)
                {
                    string filename = ex.Filename;
                    configPathBackup = filename + ".bak";
                    //_logger.Error(ex, "Cannot open config file");
                    if (File.Exists(filename) == true)
                    {
                        //_logger.Error("Config file {0} content:\n{1}", filename, File.ReadAllText(filename));
                        File.Delete(filename);
                        if (!string.IsNullOrEmpty(configPathBackup) && File.Exists(configPathBackup))
                        {
                            File.Copy(configPathBackup, filename, true);
                        }
                        
                    }
                    Kinesis.Properties.Settings.Default.Reload();
                    //_logger.Error("Config file {0} does not exist", filename);
                }
