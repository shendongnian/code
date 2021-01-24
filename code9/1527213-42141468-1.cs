    public class AnimeInfo
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public string TitleStart { get; set; }
    }
            string[] animeMainNodeString = animeMainNode.ToArray(); // Parent Nodes Array
            List<AnimeInfo> animeSubNodesList = new List<AnimeInfo>();
            // Add a child for each Parent in array
            for (int i = 0; i < animeMainNodeString.Length; i++)
            {
                string name = animeMainNodeString[i]; // Parent name in array
                //Search for a .txt files in folders with Parent Nodes names
                foreach (var subnode in Directory.GetFiles(animeGroupPath + "\\" + name, "*.txt").Select(Path.GetFileNameWithoutExtension).OrderBy(f => f))
                {
                    AnimeInfo info = new AnimeInfo();
                    //Read a text file
                    var animeFileRead = File.ReadAllLines(animeGroupPath + "\\" + name + "\\" + subnode + ".txt");
                    // Titel from this text file
                    info.Title = animeFileRead[0].Substring(animeFileRead[0].IndexOf('=') + 1);
                    // Start Date from text file
                    info.StartDate = animeFileRead[7].Substring(animeFileRead[7].IndexOf('=') + 1);
                    info.TitleStart = info.Title + "," + info.StartDate;
                    // Add to a list where are all names/start dates from this Parent       
                    animeSubNodesList.Add(info);
                }
                animeSubNodesList = animeSubNodesList.OrderBy(x => x.StarteDate).ToList();
                /*
                * Here i want to somehow sort the Names by start date
                * but i have no idea if this is possible.
                */
                foreach (var item in animeSubNodesList) // Add childNode to parent
                {
                    tvGroups.BeginUpdate();
                    tvGroups.Nodes[i].Nodes.Add(item);
                    tvGroups.EndUpdate();
                }
            
