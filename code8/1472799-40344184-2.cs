    [Designer(typeof(ControlDesigner))]
    public class MyListView : ListView
    {
        public MyListView()
        {
            this.View = System.Windows.Forms.View.Tile;
        }
        [Browsable(false)]
        new public View View
        {
            get
            {
                return System.Windows.Forms.View.Tile;
            }
            set
            {
                base.View = System.Windows.Forms.View.Tile;
            }
        }
    }
