    public void CapturarApp()
            {
                hWndApp = ScreenFuntion.getWindow("Notepad");
                if (hWndApp.ToInt32() > 0)
                {
                    ProgramsEncrustForm.MoveWindow(hWndApp,
                        0, 0,
                        Int32.Parse(Width.ToString()),
                        Int32.Parse(Height.ToString()), 1);
                    ProgramsEncrustForm.SetParent(hWndApp, new WindowInteropHelper(this).Handle);
                }
                else
                {
                    hWndApp = IntPtr.Zero;
                }
                this.Show();
            }
