    public Autodesk.Windows.RibbonPanel CreateCustomPanel()
    {
        string sPanel = "Panel Name";
        IntPtr pIcon;
        var pSource = new Autodesk.Windows.RibbonPanelSource()
        {
            Title = sPanel, 
            Id = "id_name", 
            IsSlideOutPanelVisible = true, 
            Description = null,
            DialogLauncher = null, 
            UID = null, 
            Tag = null, 
            Name = null,
        };
        var pRow1Source = new Autodesk.Windows.RibbonSubPanelSource()
        {
            Description = null, Id = "row1_shr", Name = null, Tag = null, UID = null
        };
        var pRow2Source = new Autodesk.Windows.RibbonSubPanelSource()
        {
            Description = null, Id = "row2_shr", Name = null, Tag = null, UID = null
        };
        var hPanel = new Autodesk.Windows.RibbonPanel()
        {
            Source = pSource, IsVisible = true, IsEnabled = true
        };
        var hPanelRow1 = new Autodesk.Windows.RibbonRowPanel()
        {
            Height = 32, Id = "pRow1", IsEnabled = true, IsVisible = true, Source = pRow1Source
        };
        var hPanelRow2 = new Autodesk.Windows.RibbonRowPanel()
        {
            Height = 32, Id = "pRow1", IsEnabled = true, IsVisible = true, Source = pRow2Source
        };
        Autodesk.Windows.RibbonSeparator pBreak = new Autodesk.Windows.RibbonSeparator();
        pBreak.SeparatorStyle = Autodesk.Windows.RibbonSeparatorStyle.Invisible;
        string sBtnText;
        // Add buttons to Row 1
        pIcon = Properties.Resources.YourResourceName.GetHBitmap();
        sBtnText = "Button Text";
        var pPanelBtn = new Autodesk.Windows.RibbonButton()
        {
            //SET BUTTON PROPERTIES HERE
        };
        Autodesk.Windows.ComponentManager.UIElementActivated += BtnEventHandler;
        hPanelRow1.Source.Items.Add(pPanelBtn);
        hPanelRow1.Source.Items.Add(pBreak);
        //Repeat for more buttons
        hPanel.Source.Items.Add(hPanelRow1);
        hPanel.Source.Items.Add(new Autodesk.Windows.RibbonRowBreak());
        //Repeat for second row
        hPanel.Source.Items.Add(hPanelRow2);
        return hPanel;
    }
