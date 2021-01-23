                if (ee.Button.HasFlag(MouseButtons.Left))
                {
                    Panel pa = ss as Panel;
                    int newTop =  pa.Top + ee.Y - pPt.Y;
                    if ((newTop <= pan.Top && newTop + pan.Height > f2.ClientSize.Height) ||
                        (newTop >= pan.Top && newTop <= 0))
                    {
                        if (newTop <= pan.Top && newTop + pan.Height > f2.ClientSize.Height) 
                            newTop = f2.ClientSize.Height - pan.Height;
                        pa.Top = newTop;
                    }
                }
