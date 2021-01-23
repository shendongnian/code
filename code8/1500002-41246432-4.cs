    public class Init
    {
        public ICContent AllUCContentList { get; set; }
        public ICContent ToDisplayUCContentList { get; set; }
        public Init()
        {
            // original object 
            AllUCContentList = new ICContent();
            // object dedicated to the display
            ToDisplayUCContentList = new ICContent();
        }
    }
