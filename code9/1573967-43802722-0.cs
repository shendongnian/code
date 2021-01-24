    public class MusicItems
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    
        public String Name { get; set; }
        public String Tension { get; set; }
        public String Category { get; set; }
        public String Subcategory { get; set; }
        public int ResId { get; set; }
        public int LoopStart { get; set; }
    }
    public class Playlist
    {
        public String Name { get; set; }
        public int ResId { get; set; }
        public int LoopStart { get; set; }
    }
    public class Themes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    
        public String ThemeName { get; set; }
        public String ThemeDesc { get; set; }
        public int ThemeImg { get; set; }
        public String ThemeCategory { get; set; }
        public String ThemeSubcategory { get; set; }
    }
    public class MusicInThemes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    
        public int ResId { get; set; }
        public int ThemeId { get; set; }
    }
