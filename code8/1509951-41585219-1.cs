    class Program
    {
      const byte VK_F8 = 0x77;
      const byte VK_ESC = 0x1b;
      static bool globalAppState = false;
      static void Main(string[] args)
      {
        bool lastState = IsKeyPressed(VK_F8);
        while (!IsKeyPressed(VK_ESC))
        {
          bool newState = IsKeyPressed(VK_F8);
          if (lastState != newState)
          {
            if (newState)
            {
              Console.WriteLine("F8: pressed");
              globalAppState = !globalAppState;
            }
            else
              Console.WriteLine("F8: released");
            lastState = newState;
          }
        }
      }
      static bool IsKeyPressed(byte keyCode)
      {
        return ((GetAsyncKeyState(keyCode) & 0x8000) != 0);
      }
      [DllImport("user32.dll")]
      static extern short GetAsyncKeyState(int vKey);
    }
