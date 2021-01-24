        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorAttribute(typeof(BLK_TabPageCollectionEditor), typeof(UITypeEditor))]
        [MergableProperty(false)]
        public new TabControl.TabPageCollection TabPages
        {
            get
            {
                return base.TabPages;
            }
        }
