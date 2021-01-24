      private void ApplyResources(ComponentResourceManager manager, object controls)
        {
            if (controls is Control.ControlCollection)
            {
                var ctls = (Control.ControlCollection)controls;
                //all controls
                foreach (Control ctl in ctls)
                {
                    if (ctl is RadRibbonBar)
                    {
                        var tabs = ((RadRibbonBar)ctl).CommandTabs;
                        foreach (RibbonTab tab in tabs)
                        {
                            manager.ApplyResources(tab, tab.Name);
                            ApplyResources(manager, tab.Items);
                        }
                    }
                    else
                    {
                        manager.ApplyResources(ctl, ctl.Name);
                        ApplyResources(manager, ctl.Controls);
                    }
                }
            }
            else // if (controls is RadItemOwnerCollection)
            {
                var elementCollection = controls as RadItemOwnerCollection;
                foreach (var elem in elementCollection)
                {
                    if (elem is RadRibbonBarGroup)
                    {
                        var barGroup = elem as RadRibbonBarGroup;
                        manager.ApplyResources(barGroup, barGroup.Name);
                        ApplyResources(manager, barGroup.Items);
                    }
                    else if (elem is RadRibbonBarButtonGroup)
                    {
                        var btnGroup = elem as RadRibbonBarButtonGroup;
                        manager.ApplyResources(btnGroup, btnGroup.Name);
                        ApplyResources(manager, btnGroup.Items);
                    }
                    else
                    {
                        manager.ApplyResources(elem, elem.Name);
                    }
                }
            }
         
            
        }
