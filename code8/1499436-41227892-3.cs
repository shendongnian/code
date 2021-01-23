    public class PropertyGrid : Xceed.Wpf.Toolkit.PropertyGrid.PropertyGrid
    {
        public GroupStyle GroupStyle
        {
            get;
            set;
        }
    
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
    
            PropertyItemsControl propertyItemsControl =
                Template.FindName("PART_PropertyItemsControl", this) as PropertyItemsControl;
            propertyItemsControl.GroupStyle.Clear();
            propertyItemsControl.GroupStyle.Add(GroupStyle);
        }
    }
