    public class AddPanel : IExternalApplication
    {
    
        void onViewActivated(object sender, ViewActivatedEventArgs e)
        {
            View vCurrent = e.CurrentActiveView;
            Document doc = e.Document;
            string pathname = doc.PathName;
            TaskDialog.Show("asd", pathname);
            string id = Convert.ToString(vCurrent.Id);
            string name = vCurrent.Name;
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string now = Convert.ToString(DateTime.Now);
            string content = now + ", " + id + ", " + name + ", " + userName + "\n";
             
            string path = @"E:\H1503200 Montreign Resort Casino\3-CD\views.txt";
            using (System.IO.StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine(content);
            }
        }
    
        // Both OnStartup and OnShutdown must be implemented as public method
        public Result OnStartup(UIControlledApplication application)
        {
            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("JCJ Addin");
            
            // Create a push button to trigger a command add it to the ribbon panel. 
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData buttonData = new PushButtonData("SheetsToUpper",
               "Sheets\n To Upper", thisAssemblyPath, "SheetsToUpper");
            PushButtonData buttonData1 = new PushButtonData("ViewsToUpper",
               "Views\n To Upper", thisAssemblyPath, "ViewsToUpper");
            PushButtonData buttonData2 = new PushButtonData("RenumberViews",
               "Renumber\n Views on\nSheet", thisAssemblyPath, "RenumberViews");
            PushButtonData buttonData3 = new PushButtonData("viewerLocations",
               "Find\n View on\nInstances", thisAssemblyPath, "viewerLocations");
    
            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;
            PushButton pushButton1 = ribbonPanel.AddItem(buttonData1) as PushButton;
            PushButton pushButton2 = ribbonPanel.AddItem(buttonData2) as PushButton;
            PushButton pushButton3 = ribbonPanel.AddItem(buttonData3) as PushButton;
    
            // Optionally, other properties may be assigned to the button
            // a) tool-tip
            pushButton.ToolTip = "Converts all the text in Sheet titles to uppercase - Global Operation.";
            pushButton1.ToolTip = "Converts all the text in View titles to uppercase - Global Operation.";
            pushButton2.ToolTip = "Select all views in the order you want them re-numbered.";
            pushButton3.ToolTip = "Select View.";
            // b) large bitmap
            Uri uriImage = new Uri(@"H:\!PRACTICE GROUPS\Revit Scripts\icon-font-theme-lowercase-uppercase.png");
            Uri uriImage1 = new Uri(@"H:\!PRACTICE GROUPS\Revit Scripts\icon-font-theme-lowercase-uppercase.png"); 
            Uri uriImage2 = new Uri(@"H:\!PRACTICE GROUPS\Revit Scripts\icon-font-theme-lowercase-uppercase.png");
            Uri uriImage3 = new Uri(@"H:\!PRACTICE GROUPS\Revit Scripts\icon-font-theme-lowercase-uppercase.png");
    
            BitmapImage largeImage = new BitmapImage(uriImage);
            BitmapImage largeImage1 = new BitmapImage(uriImage1);
            BitmapImage largeImage2 = new BitmapImage(uriImage2);
            BitmapImage largeImage3 = new BitmapImage(uriImage3);
    
            pushButton.LargeImage = largeImage;
            pushButton1.LargeImage = largeImage1;
            pushButton2.LargeImage = largeImage2;
            pushButton3.LargeImage = largeImage3;
    
            application.ViewActivated += new EventHandler<Autodesk.Revit.UI.Events.ViewActivatedEventArgs>(onViewActivated);
            
            return Result.Succeeded;
        }
    
        public Result OnShutdown(UIControlledApplication application)
        {
            // nothing to clean up in this simple case
            return Result.Succeeded;
        }
    }
