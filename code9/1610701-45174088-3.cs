        public static void InitBrowser( string browserName )
        {
            switch ( browserName )
            {
                case "Firefox":
                    if ( driver == null )
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add( "Firefox", Driver );
                    }
                    break;
                case "Chrome":
                    if ( driver == null )
                    {
                        driver = new ChromeDriver();
                        Drivers.Add( "Chrome", Driver );
                    }
                    break;
            }
        }
