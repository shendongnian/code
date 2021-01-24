         public class MyTextBox : TextBox
         {
        
        private static readonly int _readOnly = BitVector32.CreateMask();
        private static readonly int _shortcutsEnabled = BitVector32.CreateMask(_readOnly);
        private static int[] _shortcutsToDisable;
        private BitVector32 _textBoxFlags;
        public override bool ShortcutsEnabled
        {
            get { return _textBoxFlags[_shortcutsEnabled]; }
            set
            {
                if (_shortcutsToDisable == null)
                {
                    _shortcutsToDisable = new int[]
                    {
                        (int) Shortcut.CtrlZ,(int) Shortcut.CtrlC, (int) Shortcut.CtrlX,
                        (int) Shortcut.CtrlV, (int) Shortcut.CtrlA, (int) Shortcut.CtrlL, (int) Shortcut.CtrlR,
                        (int) Shortcut.CtrlE, (int) Shortcut.CtrlY, (int) Keys.Control + (int) Keys.Back,
                        (int) Shortcut.CtrlDel, (int) Shortcut.ShiftDel, (int) Shortcut.ShiftIns, (int) Shortcut.CtrlJ
                    };
                }
                _textBoxFlags[_shortcutsEnabled] = value;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_shortcutsToDisable == null)
            {
                return false;
            }
                var k = (int)keyData;
            switch (k)
            {
                case (int)Shortcut.CtrlL:
                    TextAlign=HorizontalAlignment.Left;
                   break;
                case (int)Shortcut.CtrlR:
                    TextAlign = HorizontalAlignment.Right;
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
    }
