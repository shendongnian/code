        private void RadPropertyGrid_AutoGeneratingPropertyDefinition(object sender, Telerik.Windows.Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs e)
        {
            string dispName = e.PropertyDefinition.DisplayName;
            // Unfortunatelly e.PropertyDefinition.Value is null, so we can't switch by object type
            switch (dispName)
            {
			    case "Property1_List":
                case "Property2_List":
                    e.PropertyDefinition.EditorTemplate = this.Resources["UniversalTemplatePropertyGrid"] as DataTemplate;
                    break;
				
				default:
				    break;
			}
		}
