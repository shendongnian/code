        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(bundle);
            
            global::Xamarin.Forms.Forms.Init(this, bundle);
            var myApp = new App();
            var mBundle = Intent.Extras;
            if (mBundle != null)
            {
                var pageName = mBundle.GetString("pageName");
                if (!string.IsNullOrEmpty(pageName))
                {
                    //get the assemblyQualifiedName of page
                    var pageAssemblyName = "Your_PCL_Name." + pageName+",Your_PCL_Name";
                    Type type = Type.GetType(pageAssemblyName);
                    if (type != null)
                    {
                        var currentPage = Activator.CreateInstance(type);
                        //set the main page
                        myApp.MainPage = (Page)currentPage;
                    }
                }
            }
               
            //load myApp
            LoadApplication(myApp);
        }
