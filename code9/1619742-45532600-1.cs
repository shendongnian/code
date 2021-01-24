    private async Task DownloadingFiles()
        {
            if (!File.Exists(dir + "modlist.txt"))
            {
                await client.DownloadFileTaskAsync(new Uri(site + "modlist.txt"), dir + "modlist.txt");
            }
        }
        private async Task DownloadingMods()
        {
            var files = File.ReadAllLines(dir + "modlist.txt");
            foreach (var filename in files)
            {
                if (!File.Exists(dir + "mods/" + filename))
                {
                    await client.DownloadFileTaskAsync(new Uri(site + "mods/" + filename), dir + "mods/" + filename);
                }
            }
        }
