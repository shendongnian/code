            foreach (UIElement element in SettingsGrid.Children)
            {
                System.Diagnostics.Debug.WriteLine(element.GetType());
                if (element.GetType().Name is "Slider")
                {
                    var elementNew = element as Slider;
                    ParaValue.Text = elementNew.Value.ToString();
                }
                
            }
