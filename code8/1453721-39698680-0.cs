    private void send_Click(object sender, EventArgs e)
    {
     var notepad = Process.GetProcessesByName("Notepad").FirstOrDefault(p => p.MainWindowTitle == "Untitled - Notepad");
    
                if (notepad != null)
                {
                    if (IsIconic(notepad.MainWindowHandle))
                        ShowWindow(notepad.MainWindowHandle, 9);
    
                    SetForegroundWindow(notepad.MainWindowHandle);
                    string text = "";
    
                    foreach (var item in listBox1.Items)
                    {
                        text = item.ToString();
                        Clipboard.SetText(text);
                        SendKeys.Send("^V");
                        SendKeys.Send("{ENTER}");
                        System.Threading.Thread.Sleep(150);
                    }
    
                }
    }
