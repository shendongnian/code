        public virtual void ClearSelection() {
            for (int i=0; i < Items.Count; i++)
                Items[i].Selected = false;
        }
        public virtual int SelectedIndex {
            set {
                ...
                if ((Items.Count != 0 && value < Items.Count) || value == -1) {
                    ClearSelection();
                    if (value >= 0) {
                        Items[value].Selected = true;
                    }
                }
                ...
            }
