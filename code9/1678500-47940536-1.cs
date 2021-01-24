    fileneed = fileneed.Distinct().ToList<string>();
    for (int i = fileneed.Count - 1; i >= 0; i--)
    {
        if (fileneed[i].Contains("."))
        {
            using (var w = new WebClient())
            using (var webFile = w.OpenRead("http://mywebsite.org/collab/files.php?act=need&user=" + Properties.Settings.Default.user + "&file=" + fileneed[i]))
            using (var diskFile = File.OpenWrite(fileneed[i]))
            {
                webFile.CopyTo(diskFile);
            }
            fileneed.RemoveAt(i);
        }
    }
