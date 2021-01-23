    public partial class _Default : Page
    {
        protected IList<Tour> tours;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            tours= new List<Tour>();
            tours.Add(new Tour()
            {
                ImageUrl = "img.png",
                Title = "Hello World",
                Text = "This Is The Body Text"
            });
            tours.Add(new Tour()
            {
                ImageUrl = "img2.png",
                Title = "Tour two",
                Text = "This Is The Body Text2"
            });
        }
    }
    public class Tour
    {
        public string ImageUrl { get; internal set; }
        public string test { get; set; }
        public string Text { get; internal set; }
        public string Title { get; internal set; }
    }
