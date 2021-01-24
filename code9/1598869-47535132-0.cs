        string phyle;
        string ffilelist = "";
        public void listfiles()
        {
            try
            {
                var path1 = "/storage/emulated/0/Music/";
                var mp3Files = Directory.EnumerateFiles(path1, "*.mp3", SearchOption.AllDirectories);           
                foreach (string currentFile in mp3Files)
                {
                    phyle = currentFile;
                    ffilelist = ffilelist + "\n" + phyle;
                }
                //playpath(phyle); // play the last file found
            }
            catch (Exception e9)
            {              
                Toast.MakeText(ApplicationContext, "ut oh\n"+e9.Message , ToastLength.Long).Show();
            }
        }
