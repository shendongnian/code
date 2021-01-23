    public class RichTextBoxKorean : RichTextBox 
    {
        [DllImport("imm32.dll", CharSet = CharSet.Unicode)]
        private static extern int ImmGetCompositionString(IntPtr hIMC, uint dwIndex, byte[] lpBuf, int dwBufLen);
        [DllImport("imm32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr ImmGetContext(IntPtr hWnd);
        [DllImport("imm32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr ImmReleaseContext(IntPtr hWnd, IntPtr context);
        public enum WM_IME
        {
            GCS_RESULTSTR = 0x800,
            EM_STREAMOUT = 0x044A,
            WM_IME_COMPOSITION 	=0x10F,
            WM_IME_ENDCOMPOSITION 	=0x10E, 	
            WM_IME_STARTCOMPOSITION 	=0x10D
        }
        private bool skipImeComposition = false;
        private bool imeComposing = false;
        public bool KoreanWorkaroundEnabled = true;
        string _mText = "";
        protected override void WndProc(ref Message m)
        {
            if (KoreanWorkaroundEnabled)
            {
                switch (m.Msg)
                {
                    case (int)WM_IME.EM_STREAMOUT:
                        if (imeComposing)
                        {
                            skipImeComposition = true;
                        }
                        base.WndProc(ref m);
                        break;
                    case (int)WM_IME.WM_IME_COMPOSITION:
                        if (m.LParam.ToInt32() == (int)WM_IME.GCS_RESULTSTR)
                        {
                            IntPtr hImm = ImmGetContext(this.Handle);
                            int dwSize = ImmGetCompositionString(hImm, (int)WM_IME.GCS_RESULTSTR, null, 0);
                            byte[] outstr = new byte[dwSize];
                            ImmGetCompositionString(hImm, (int)WM_IME.GCS_RESULTSTR, outstr, dwSize);
                            _mText += Encoding.Unicode.GetString(outstr).ToString();
                            ImmReleaseContext(this.Handle, hImm);
                        }
                        if (skipImeComposition)
                        {
                            skipImeComposition = false;
                            break;
                        }
                        base.WndProc(ref m);
                        break;
                    case (int)WM_IME.WM_IME_STARTCOMPOSITION:
                        imeComposing = true;
                        base.WndProc(ref m);
                        break;
                    case (int)WM_IME.WM_IME_ENDCOMPOSITION:
                        imeComposing = false;
                        base.WndProc(ref m);
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
            else
                base.WndProc(ref m);
        }
        public override string Text
        {
            get
            {
                if (!imeComposing)
                {
                    _mText = base.Text;
                    return base.Text;
                }
                else
                {
                    return _mText;
                }
            }
            set
            {
                base.Text = value;
                _mText = value;
            }
        }
    }
