    namespace classTest
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            World newWorld = new World();
            Continent Europe = new Continent();
            Europe.name = "Europe";
            Country England = new Country();
            England.name = "England";
            List<string> imageUrl = new List<string>();
            imageUrl.Add("url1-England");
            imageUrl.Add("url2-England");
            imageUrl.Add("url3-England");
            England.imageUrls = imageUrl;
            Europe.countries.Add(England);
            newWorld.continents.Add(Europe);
            Country France = new Country();
            France.name = "France";
            imageUrl = new List<string>();
            imageUrl.Add("url1-France");
            imageUrl.Add("url2-France");
            imageUrl.Add("url3-France");
            France.imageUrls = imageUrl;
            Europe.countries.Add(France);
            foreach (Continent continent in newWorld.continents)
            {
                Console.WriteLine(continent.name);
                foreach (Country country in continent.countries)
                {
                    Console.WriteLine(country.name);
                    foreach(string imageUri in country.imageUrls)
                    {
                        Console.WriteLine(imageUri);
                    }
                }
            }
        }
    }
    public class World
    {
        public List<Continent> continents;
        public World()
        {
            continents = new List<Continent>();
        }
    }
    public class Continent
    {
        public string name;
        public List<Country> countries { get; set; }
        public Continent()
        {
            name = string.Empty;
            countries = new List<Country>();
        }
    }
    public class Country
    {
        public string name { get; set; }
        public List<string> imageUrls { get; set; }
        public Country()
        {
            name = string.Empty;
            imageUrls = new List<string>();
        }
    }
    }
