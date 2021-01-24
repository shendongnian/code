    public class TabConrolEx : TabControl {
      public event ScrollEventHandler Scrolling;
      private const int WM_HSCROLL = 0x114;
      private int oldValue = 0;
      protected override void WndProc(ref Message m) {
        base.WndProc(ref m);
        if (m.Msg == WM_HSCROLL) {
          this.OnScrolling(new ScrollEventArgs(((ScrollEventType)LoWord(m.WParam)), 
            oldValue, HiWord(m.WParam), ScrollOrientation.HorizontalScroll));
        }
      }
      protected void OnScrolling(ScrollEventArgs e) {
        if (Scrolling != null) {
          Scrolling(this, e);
        }
        if (e.Type == ScrollEventType.EndScroll) {
          oldValue = e.NewValue;
        }
      }
      private int LoWord(IntPtr dWord) {
        return dWord.ToInt32() & 0xffff;
      }
      private int HiWord(IntPtr dWord) {
        if ((dWord.ToInt32() & 0x80000000) == 0x80000000) {
          return (dWord.ToInt32() >> 16);
        } else {
          return (dWord.ToInt32() >> 16) & 0xffff;
        }
      }
    }
