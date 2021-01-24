    bool monitoring = false;
    while (true)
    {
       if (!monitoring) //Start monitoring or restart monitoring
       {
          Debug.WriteLine("start");
          ThisAddIn_Startup();
          monitoring = true;
       }
       Process[] outlook;
       new Thread(() => {
         outlook = Process.GetProcessesByName("blabla");
       }.Start();
       Thread.Sleep(1000);
    }
    
    
    private void ThisAddIn_Startup()
    {
       _OutlookApplication = new Outlook.Application();
    
       //Link Inbodx Events
       _olFolderInbox.Items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(Item_Calendar_Change);
    
       //Link Calendar Events
       _olFolderCalendar.Items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(Item_Calendar_Add);
       _olFolderCalendar.Items.ItemChange += new Outlook.ItemsEvents_ItemChangeEventHandler(Item_Calendar_Change);
       _olFolderCalendar.Items.ItemRemove += new Outlook.ItemsEvents_ItemRemoveEventHandler(Item_Calendar_Deleted);
    }
