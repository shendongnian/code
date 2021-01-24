       private void btnLoad_Click(object sender, EventArgs e)
        {
            string line;
            using (StreamReader reader = new StreamReader(@"c:\temp\music\playlist.mpl"))
            {
                line = reader.ReadLine();
            }
            var jobj = JsonConvert.DeserializeObject<List<Music>>(line);
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var musiclist = new List<Music>();
            var objSongs = System.IO.Directory.GetFiles(@"C:\temp\music\");
            foreach (var song in objSongs)
            {
                musiclist.Add(new Music { Name = song });
            }
            var ret = Newtonsoft.Json.JsonConvert.SerializeObject(musiclist);
            using (var sw = new StreamWriter(@"c:\temp\music\playlist.mpl"))
            {
                sw.Write(ret);
                sw.Flush();
            }
        }
    public class Music
    {
        public string Name { get; set; }
    }
