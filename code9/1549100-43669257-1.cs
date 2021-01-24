    Autodesk.Windows.RibbonControl pRibbon = Autodesk.Windows.ComponentManager.Ribbon;
    foreach (var pTab in pRibbon.Tabs)
    {
        if (pTab.Id == "Modify")
        {
            pTab.Panels.Add(CreateCustomPanel());
            break;
        }
    }
 
