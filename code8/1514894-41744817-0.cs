        [DllImport("user32.dll")]
        public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
		public class messagebox_control
        {
            const int WM_LBUTTONDOWN = 0x2201;
            const int WM_LBUTTONUP = 0x0202;
            const int BM_CLICK = 0x00F5;
            public void Click_message()
            {
                int nhwnd = FindWindow("#32770", "웹 페이지 메시지");
                if(nhwnd>0)
                {
                    int hw1 = FindWindowEx(nhwnd, 0, "DirectUIHWND", "");
                    if(hw1>0)
                    {
                        int hw2 = FindWindowEx(hw1, 0, "CtrlNotifySink", "");
                        if(hw2>0)
                        {
                            while(true)
                            {
                                int hw3 = FindWindowEx(hw2, 0, "Button", "확인");
                                if (hw3>0)
                                {
                                    SendMessage(hw3, BM_CLICK, 0, 1);
                                    break;
                                }
                                hw2 = FindWindowEx(hw1, hw2, "CtrlNotifySink", "");
                                if (hw2==0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
	}
