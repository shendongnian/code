        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            var scrollBar = gridControl1.Controls.OfType<VCrkScrollBar>().FirstOrDefault();
            scrollBar.Scroll += ScrollBar_Scroll;
        }
        private void ScrollBar_Scroll(object sender, ScrollEventArgs e) {
            if (e.NewValue == ((IScrollBar)sender).ViewInfo.VisibleMaximum) {
                LoadMoreData();
            }
        }
