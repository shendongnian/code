    public class MyListView : ListView
    {
        const int WM_LBUTTONDOWN = 0x0201;
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                int x = (m.LParam.ToInt32() & 0xffff);
                int y = (m.LParam.ToInt32() >> 16) & 0xffff;
                var item = this.HitTest(x, y).Item;
                if (item != null)
                    item.Selected = !item.Selected;
                else
                    base.DefWndProc(ref m);
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }
    }
