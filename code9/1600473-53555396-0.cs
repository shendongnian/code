    private void SetRibbonVisibility(bool visible)
        {
            foreach (var ribbonGroup in Globals.Ribbons.Ribbon.MyRibbonTab.Groups)
            {
                ribbonGroup.Visible = visible;
            }
        }
