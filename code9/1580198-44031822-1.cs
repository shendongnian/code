    private static readonly _fileMutex = new object();
    public void SaveAll(int volume, int duration, string playing, int 
                            LBPindex, int LBSindex, string URL, int maximum)
    {
        lock (_fileMutex) 
        {
            var filePath = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData), "SaveDATA.bin");
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {
                    sw.WriteLine("SETTINGS" + "|" + volume + "|" + duration + "|" + playing + "|" + LBPindex + "|" + LBSindex + "|" + URL + "|" + maximum);
    
                    foreach (var item1 in Playlist.SavedPlaylists)
                    {
                        sw.Write("PLAYLIST" + "|" + item1.Name + "|");
                        foreach (var item2 in item1.SavedSongs)
                        {
                            sw.WriteLine(item2.Path + "|" + item2.Title + "|" + item2.Author + "|" + item2.Album + "|" + item2.Release + "|" + item2.Genre + "|" + item2.Comment);
                        }
                    }
                    sw.Close();
                }
                fs.Close();
            }
        }
    }
