    public class ExpandAllBehavior : Behavior<GridControl>
    {
        public static readonly DependencyProperty HasLotPartieProperty =
        DependencyProperty.Register("HasLotPartie", typeof(bool), typeof(ExpandAllBehavior));
        public bool HasLotPartie
        {
            get { return (bool)GetValue(HasLotPartieProperty); }
            set { Console.WriteLine(value.ToString() + "-------------------------------------------------------------------------------------------------------------------"); SetValue(HasLotPartieProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded; //Apllied after GridControl is fully loaded.
            this.AssociatedObject.CustomRowFilter += AssociatedObject_Loaded; //Applied after filtering on Rows
        }
        void AssociatedObject_Loaded(object sender, EventArgs e)
        {
            if (HasLotPartie)
            {
                int dataRowCount = AssociatedObject.VisibleRowCount;
                for (int rowHandle = 0; rowHandle < dataRowCount; rowHandle++)
                    AssociatedObject.ExpandMasterRow(rowHandle);
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
