    [DllImport("user32.dll")] static extern int FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")] static extern int SendMessage(int  hWnd, int wMsg, int wParam, int lParam);
        // This function endlessly waits for window with the given title
        // and when found sens it a WM_CLOSE message (16)
        public static void killMbox(Object windowTitle)
        {
            for (int h = 0; h == 0;)
            {   Thread.Sleep(1000);
                h = FindWindow(null, windowTitle.ToString());
                if (h != 0)
                    SendMessage(h, 16, 0, 0);
            }
        }
        static void Main(string[] args)
        {
           Thread mboxKiller = new Thread(killMbox);
           // Excel message-boxes usually have title "Microsoft Excel".
           // Change if your message-box has a different title
           mboxKiller.Start("Microsoft Excel");
            Application xlApp = new Application();
            Workbook wb = xlApp.Workbooks.Open("C:/SO/SO.xlsm");
            xlApp.Visible = true;
            xlApp.Run("doMessageBox"); // launches a macro that displays a message box
            // now the mboxKiller will kill that mbox, code here proceeds
            // ...
            xlApp.Quit();
        }
    }
