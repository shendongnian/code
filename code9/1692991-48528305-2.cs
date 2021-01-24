    static bool recToggle = false;
    static bool mouseBool = false;
    static DateTime start = DateTime.Now;
    static List<TimeSpan> list = new List<TimeSpan>();
    private static IntPtr HookCallback(
        int nCode, IntPtr wParam, IntPtr lParam)
    {
      if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
      {
        //mouse down
        if (mouseBool && recToggle)
        {
          mouseBool = false;
          start = DateTime.Now;
        }
        else if (!mouseBool && recToggle)
        {
          mouseBool = true;
          TimeSpan ts = DateTime.Now.Subtract(start);
          list.Add(ts);
        }
      }
      if (nCode >= 0 && MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam)
      {
        //mouse up
      }
      return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }
    private void button1_Click(object sender, EventArgs e)
    {
      if (recToggle)
      {
        button1.Text = "Start Recording";
        //REC IS OFF!
        string s = string.Empty;
        foreach (TimeSpan delay in list)
        {
          s += delay.TotalMilliseconds.ToString() + " ";
        }
        MessageBox.Show(s); //show how many items
        list.Clear();
        recToggle = false;
      }
      else
      {
        button1.Text = "Stop Recording";
        list.Clear();
        //REC IS ON!
        recToggle = true;
        start = DateTime.Now;
      }
    }
