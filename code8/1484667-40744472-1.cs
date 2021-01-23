    protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_PAINT:
                        mBaseControl.Invalidate();
                        OnPaint();
                        base.WndProc(ref m);
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
                
            }
