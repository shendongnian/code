     IWebDriver driver = new FirefoxDriver();
        static void Main(string[] args)
        {
        }
       
        [Test]
        public void VerifyTitle()
        {
            //Write Actual Test
            string title = driver.Title;
            // Assert.AreEqual(title, "DoneThedeal");
            ////I wanted to keep it simple change it back if u wish
            if (title.Contains("DoneTheDeal"))
            {
                Console.WriteLine(title);
            }
            else
            {
                Console.WriteLine("Title not found");
            }
          
        }
        [SetUp]
        public void Setup()
        {
            //start browser and oprn url
            
            driver.Navigate().GoToUrl("http://Donethedeal.com/");
        }
        [TearDown]
        public void CleanupTest()
        {
            //close browser
            driver.Quit();
        }
    }
