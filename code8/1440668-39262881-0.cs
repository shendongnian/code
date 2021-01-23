        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        private void FindAppSetFocusAndSendKeyStrokes()
        {
            TryFindWindowAndSetFocus("ThunderRT6FormDC", "Human Resource Management System");
            SendKeyStrokes("%ML{ENTER}");
        }
        private void TryFindWindowAndSetFocus(string strClassName, string strCaption)//If you can't find strClassName, use String.Empty instead.
        {
            Thread.Sleep(1000);
            int intCounter = 0;
            IntPtr processHandler = FindWindow(strClassName, strCaption);
            while (processHandler == IntPtr.Zero)
            {
                if (intCounter > 9)
                    break;
                Thread.Sleep(1000);
                processHandler = FindWindow(strClassName, strCaption);
                intCounter++;
            }
            if (processHandler == IntPtr.Zero)
                throw new Exception("Could not find the Process Window");
            intCounter = 0;
            while (!SetForegroundWindow(processHandler))
            {
                if (intCounter > 9)
                    break;
                Thread.Sleep(500);
                intCounter++;
            }
            if (intCounter > 9)
                throw new Exception("Could not set Process foreground window");
        }
        private void SendKeyStrokes(string strKeys)
        {
            Thread.Sleep(100);
            SendKeys.SendWait(strKeys);
            SendKeys.Flush();
        }
