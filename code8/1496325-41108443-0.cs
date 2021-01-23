        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        static void Main(string[] args)
        {
            short? previousState = null;
            while (true)
            {
                var state = GetAsyncKeyState(System.Windows.Forms.Keys.Add);
                if (state != previousState)
                {
                    Console.WriteLine(state);
                    previousState = state;
                }
            }
        }
