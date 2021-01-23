     private void Button_Click_1(object sender, RoutedEventArgs e)
                {
        
                    var notepad = Process.GetProcessesByName("Notepad").FirstOrDefault(p => p.MainWindowTitle == "Untitled - Notepad");
                    if (notepad != null)
                    {
                        if (IsIconic(notepad.MainWindowHandle))
                            ShowWindow(notepad.MainWindowHandle, 9);
        
                        var input = new InputSimulator();
                        SetForegroundWindow(notepad.MainWindowHandle);
                        foreach (var item in listBox1.Items)
                        {
                            input.Keyboard.TextEntry(item.ToString());
                            input.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        
                        }
                    }
                }
