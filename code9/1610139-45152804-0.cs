            byte[] blackboxBytes = Convert.FromBase64String(backBoxBase64);
            var uniqueTempFolder = 
                     Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), 
                                                     Path.GetRandomFileName()));
            var zipFilePath = Path.Combine(uniqueTempFolder.FullName, 
                                                                "BlackBox.zip");
            using (StreamWriter writer = new StreamWriter(zipFilePath))
            {
                writer.Write(blackboxBytes);
            }
            sendEmail(deviceFQN, message, ZipFilePath);
            s_Log.Warn("Email sent");
            //recursive delete of the whole folder
            uniqueTempFolder.Delete(true);
            s_Log.Warn("In BB zipFilePath after delete");
