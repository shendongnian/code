    class Program
    {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        static void Main(string[] args)
        {
            while (GetAsyncKeyState('Q') == 0)
            {
                short result = GetAsyncKeyState('A');
                if (result < 0 && (result & 0x01) == 0x01)
                    Console.WriteLine("A pressed and up");
            }
        }
    }
