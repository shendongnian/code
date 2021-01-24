        public ActionResult MyPro()
        {
            Dictionary<string, dynamic> myProData = new Dictionary<string, dynamic>();
            ConfigurationManager.AppSettings.AllKeys.ToList().ForEach
            (
                settingsKey =>
                myProData.Add(settingsKey, ConfigurationManager.AppSettings[settingsKey]);
            );
            var myProModel = new myProModel(myProData);
            return View(myProModel);
        }
