    public class MusicFile
    {
        public string Path;
        public string FileName;
        public override string ToString()
        {
            return FileName;
        }
    }
    private void PopulateListBox1(string folder)
    {
        string[] files = Directory.GetFiles(folder);
        foreach (string file in files)
        {
            var music = new MusicFile
            {
                Path = file,
                FileName = Path.GetFileNameWithoutExtension(file)
            };
            listBox1.Items.Add(music);
        }
    }
