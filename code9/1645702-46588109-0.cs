    public class DataGridViewFocused : DataGridView
    {
        public bool? ShowFocus { get; set; }
        protected override bool ShowFocusCues
        {
            get
            {
                return this.ShowFocus.HasValue? this.ShowFocus.Value : base.ShowFocusCues;
            }
        }
    }
