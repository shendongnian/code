        public ActionResult MyPro()
        {
            Dictionary<string, dynamic> myProData = new Dictionary<string, dynamic>();
            ConfigurationManager.AppSettings["ConfigItemsToMonitor"].Split(',').ToList().ForEach
            (
                settingsKey =>
                myProData.Add(settingsKey, ConfigurationManager.AppSettings[settingsKey]);
            );
            var myProModel = new myProModel(myProData);
            return View(myProModel);
        }
