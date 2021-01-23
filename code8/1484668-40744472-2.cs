    protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_PAINT:
                        mBaseControl.Invalidate();
                        base.WndProc(ref m);
                        OnPaint();
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
                
            }
