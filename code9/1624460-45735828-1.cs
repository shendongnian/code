        public static void SetWidthFromItems(this ComboBox comboBox, HashSet<string> measuredWidthNamesSet)
        {
            double comboBoxWidth = 19;// comboBox.DesiredSize.Width;
            // Create the peer and provider to expand the comboBox in code behind. 
            ComboBoxAutomationPeer peer = new ComboBoxAutomationPeer(comboBox);
            IExpandCollapseProvider provider = (IExpandCollapseProvider)peer.GetPattern(PatternInterface.ExpandCollapse);
            EventHandler eventHandler = null;
            eventHandler = new EventHandler(delegate
            {
                if (comboBox.IsDropDownOpen &&
                    comboBox.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                {
                    bool isSuccess = true;
                    double width = 0;
                    foreach (var item in comboBox.Items)
                    {
                        var container = comboBox.ItemContainerGenerator.ContainerFromItem(item);
                        if (container is ComboBoxItem)
                        {
                            var comboBoxItem = (ComboBoxItem) container;
                            comboBoxItem.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                            if (comboBoxItem.DesiredSize.Width > width)
                            {
                                width = comboBoxItem.DesiredSize.Width;
                            }
                        }
                        else
                        {
                            /* coming here means that for some reason ComboBoxItems are not generated even if
                             * comboBox.ItemContainerGenerator.Status seems to be OK */
                            isSuccess = false;
                            break;
                        }
                    }
                    if (isSuccess)
                    {
                        comboBox.Width = comboBoxWidth + width;
                        measuredWidthNamesSet.Add(comboBox.Name);
                    }
                    // Remove the event handler. 
                    comboBox.ItemContainerGenerator.StatusChanged -= eventHandler;
                    comboBox.DropDownOpened -= eventHandler;
                    provider.Collapse();
                }
            });
            comboBox.ItemContainerGenerator.StatusChanged += eventHandler;
            comboBox.DropDownOpened += eventHandler;
            // Expand the comboBox to generate all its ComboBoxItem's. 
            provider.Expand();
        }
