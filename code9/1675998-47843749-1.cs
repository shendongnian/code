    protected Process _SysClockProcess;
    public void RunDll_Process()
    {
       //Define properties for Process.start()
       ProcessStartInfo psInfo = new ProcessStartInfo();
       psInfo.UseShellExecute = true;
       psInfo.FileName = "rundll32.exe";
       psInfo.Arguments = "shell32.dll, Control_RunDLL timedate.cpl,,0"; //<- 0 = First Tab
       psInfo.WindowStyle = ProcessWindowStyle.Normal;
       _SysClockProcess = new Process();
       _SysClockProcess.StartInfo = psInfo;
       _SysClockProcess.Start();
       //Set the Sync Object to the current Form
       _SysClockProcess.SynchronizingObject = this;
       //Enable this Process to raise events
       _SysClockProcess.EnableRaisingEvents = true;
       //Add an event handler for the Exited event
       _SysClockProcess.Exited += new EventHandler(this.Exited);
    
       //Wait until the Clock Window is ready
       _SysClockProcess.WaitForInputIdle();
    
       //Insert the Window title. It's case SENSITIVE
       //Window Title in HKEY_CURRENT_USER\Software\Classes\Local Settings\MuiCache\[COD]\[LANG]\
       string _WindowTitle = "Date and Time";
       int _MaxLenght = 256;
       SetWindowPosFlags _flags = SetWindowPosFlags.NoSize |
                                  SetWindowPosFlags.AsyncWindowPos |
                                  SetWindowPosFlags.ShowWindow;
    
       //The first thread is the Main thread. All Dialog windows' handles are attached here.
       //The second thread is for GDI+ Hook Window. Ignore it.
       //(hWnd, lParam) matches the EnumThreadWndProc Callback signature
       EnumThreadWindows((uint)_SysClockProcess.Threads[0].Id, (hWnd, lParam) => 
                               {
                                  StringBuilder lpString = new StringBuilder(_MaxLenght);
                                  if (GetWindowText(hWnd, lpString, _MaxLenght) > 0)
                                     if (lpString.ToString() == _WindowTitle)
                                     {
                                        RECT lpRect;
                                        //Get the Clock Window client area rectangle
                                        GetWindowRect(hWnd, out lpRect);
                                        Size _size = new Size(lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top);
                                        //Caculate the position of the Clock Windows relative to the ref. Form Size
                                        SetWindowPos(hWnd, (IntPtr)0, ((this.Width + this.Left) - _size.Width), 
                                                                      ((this.Height + this.Top) - _size.Height), 
                                                                      0, 0, _flags);
                                        //Return false to end the enumeration
                                        return false;
                                     }
                                  //Window not found: return true to continue the enumeration
                                  return true;
                               }, ref _WindowTitle);
    
       //Wait for the Process to Exit (when the Clock Window is closed).
       _SysClockProcess.WaitForExit();
       _SysClockProcess.Exited -= this.Exited;
       _SysClockProcess.Close();
       //Dispose of this object only if not needed anymore. 
       //Otherwise, it's better to dispose of it when the form is disposed.
    }
    
    //This event is raised when the Clock Window closes
    protected void Exited(Object source, EventArgs e)
    {
       if (_SysClockProcess.HasExited == true)
          Console.WriteLine("The process has exited. Code: {0}  Time: {1}", 
                            _SysClockProcess.ExitCode, 
                            _SysClockProcess.ExitTime);
    }
