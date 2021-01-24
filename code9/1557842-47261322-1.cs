    // this will be a watcher that checks if is new content... if there is, delete the existing .wpl file and recreate the .wpl with new content links included        
        private void CreateNewPlayList(string folder)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                fileName = getDrive(folder) + @"\" + folder + "Playlist.wpl";
                FileInfo fileInfo = new FileInfo(fileName);
                String f = @"<?wpl version=""1.0""?> 
               <smil>
               <head><meta name=""Generator"" content=""Microsoft Windows Media 
             Player -- 10.0.0.3646""/>   
               <author/>
              <title> a title goes here </title>
              </head>
              <body>
              <seq> ";
                  String ff = @"
             </seq> 
             </body> 
             </smil>";
                   using (FileStream fs = fileInfo.Create())
                {
                    Byte[] txt = new UTF8Encoding(true).GetBytes(f);
                    fs.Write(txt, 0, txt.Length);
                    ////write paths and load only certain file types according to requirements into array
                    String[] extentions = { "*.mp4", "*.wmv", "*.JPG".ToLower(), "*.ppt", "*.png" };
                    List<string> files = new List<string>();
                    foreach (string filter in extentions)
                    {
                        files.AddRange(System.IO.Directory.GetFiles(getDrive(folder) + @"\", filter));
                    }
                    int filecount = files.Count;
                    string[] video_lists = new string[files.Count];
                    int counts = 0;
                    foreach (string file in files)
                    {
                        video_lists[counts] = file.ToString();
                        string PathfileName = Path.GetFileName(file);
                        Byte[] author;
                        //use the ppt to be able to go into the folder and add each slide as part of the playlist
                        if (Path.GetExtension(PathfileName) == ".ppt" || Path.GetExtension(PathfileName) == ".pptx")
                        {
                            //create a loop to loop through the folder that has the same name as ppt/pptx(PathFileName)
                            string pptDrive = getDrive(folder) + @"\" + Path.GetFileNameWithoutExtension(PathfileName) + @"\";
                            if (Directory.Exists(pptDrive))
                            {
                                string[] pptFilesFolder = Directory.GetFiles(pptDrive);
                                int counter = 1;
                                while (counter <= pptFilesFolder.Length)
                                {
                                    foreach (string pptFile in pptFilesFolder)
                                    {
                                        string pptFileName = Path.GetFileName(pptFile);
                                        string pptFileNameNoExt = Path.GetFileNameWithoutExtension(pptFile);                                                                         
                                        
                                        int i = pptFilesFolder.Length;
                                        int ss = Convert.ToInt16(new String(pptFileNameNoExt.Where(Char.IsDigit).ToArray()));
                                        if (ss <= i && ss == counter)
                                        {
                                            author = new UTF8Encoding(true).GetBytes(@"<media src=""" + pptDrive + @"\" + pptFileName + "\"/>");
                                            fs.Write(author, 0, author.Length);
                                            counter++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //do something...
                            }
                        }
                        else
                        {
                            author = new UTF8Encoding(true).GetBytes(@"<media src=""" + getDrive(folder) + @"\" + PathfileName + "\"/>");
                            fs.Write(author, 0, author.Length);
                        }
                        counts = counts + 1;
                    }
                    Byte[] toptxt = new UTF8Encoding(true).GetBytes(ff);
                    fs.Write(toptxt, 0, toptxt.Length);
                }
            }
            catch (IOException io)
            {
                //error handling....
                return;
            }
            catch (Exception ex)
            {
                //error handling...
                return;
            }
        }
