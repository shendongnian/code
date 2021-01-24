    public static class Globals
    {
        static Globals()
        {
            mainScreenfontSize = 40.0;
        }
        public static double mainScreenfontSize { get; set; }
    }
----------
    <Label FontSize="{x:Static local:Globals.mainScreenfontSize}" Content="Some big content"/>
