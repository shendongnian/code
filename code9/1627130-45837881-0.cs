    private Dictionary<string, ControlTemplate> collection
    {
        get
        {
            Dictionary<string, ControlTemplate> controlTemplates = new Dictionary<string, ControlTemplate>();
            controlTemplates.Add("ResourceName", FindResource("ResourceName") as ControlTemplate);
            return controlTemplates;
        }
    }
----
        Label LBDisConnect = new Label();
        LBDisConnect.Template = collection["ResourceName"];
        LoginInfo.Children.Add(LBDisConnect);
