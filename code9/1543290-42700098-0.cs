    public static void RaiseGeneratedNotification(int errors, int warnings)
    {
        // Get a toast XML template
        XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);
        
        // Fill in the text elements
        XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
        stringElements[0].AppendChild(toastXml.CreateTextNode("Web Studio"));
        stringElements[1].AppendChild(toastXml.CreateTextNode(Strings.Errors+": "+errors));
        stringElements[2].AppendChild(toastXml.CreateTextNode(Strings.Warnings+": " +warnings));
        
        // Specify the absolute path to an image
        String imagePath = "file:///" + Path.GetFullPath("App.png");
        XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
        imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;
        // Create the toast and attach event listeners
        ToastNotification toast = new ToastNotification(toastXml)
        {
            ExpirationTime = DateTimeOffset.Now.AddMinutes(2)
        };
        // Show the toast. Be sure to specify the AppUserModelId on your application's shortcut!
        ToastNotificationManager.CreateToastNotifier(Resources.AppId).Show(toast);
    }
