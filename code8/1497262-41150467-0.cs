        static void Main()
        {
            var state = GetState();
            if (state != "Ok")
            {
                Debug.WriteLine(state);
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        static string GetState()
        {
            return "x";
        }
