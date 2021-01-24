    if(dg.ItemContainerGenerator.Status == GeneratorStatus.NotStarted)
                            {
                                dg.IsDropDownOpen = true;
                                this.UpdateLayout();
                                dg.IsDropDownOpen = false;
                            }
