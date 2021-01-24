    class Program
    {
        private const int VK_ESCAPE = 0x1B;
        private const int WM_KEYDOWN = 0x0100;
        [DllImport("User32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetConsoleWindow();
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                bool hasSucceeded = PostMessage(GetConsoleWindow(), WM_KEYDOWN, VK_ESCAPE, 0);
                return;
            });
            Console.WriteLine("PostMessage works as expected in Debug >> Start Debugging mode.");
            if ((Console.ReadKey()).Key == ConsoleKey.Escape)
                return;
        }
    }
