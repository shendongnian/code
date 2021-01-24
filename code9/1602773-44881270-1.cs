        public string GetCustomUI(string ribbonID)
        {
            string ribbonXML = String.Empty;
            if (ribbonID == "Microsoft.Outlook.Mail.Compose")
            {
                ribbonXML = GetResourceText("Trin_RibbonOutlookBasic.Ribbon1.xml");
            }
            return ribbonXML;
        }
