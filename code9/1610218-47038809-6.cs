    public partial class OptionOneMenuItem : HamburgerMenuGlyphItem
    {
        public OptionOneMenuItem()
        {
            Glyph = "/Assets/OptionOne.png";
            Label = "Option One";
            Command = ApplicationCommands.NavigateCommand;
            CommandParameter = typeof(OptionOnePageView);
    
            InitializeComponent();
        }
    }
