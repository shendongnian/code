    void mouseHook_MouseMove(object sender, MouseEventArgs e)
    {
        events.Add(
            new MacroEvent(
                MacroEventType.MouseMove,
                e,
                Environment.TickCount - lastTimeRecorded
            ));
        lastTimeRecorded = Environment.TickCount;
    }
    void mouseHook_MouseDown(object sender, MouseEventArgs e)
    {
        events.Add(
            new MacroEvent(
                MacroEventType.MouseDown,
                e,
                Environment.TickCount - lastTimeRecorded
            ));
        lastTimeRecorded = Environment.TickCount;
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        foreach (MacroEvent macroEvent in events)
        {
            Thread.Sleep(macroEvent.TimeSinceLastEvent);
            switch (macroEvent.MacroEventType)
            {
                case MacroEventType.MouseMove:
                    {
                        MouseEventArgs mouseArgs = (MouseEventArgs)macroEvent.EventArgs;
                        MouseSimulator.X = mouseArgs.X;
                        MouseSimulator.Y = mouseArgs.Y;
                    }
                    break;
                case MacroEventType.MouseDown:
                    {
                        MouseEventArgs mouseArgs = (MouseEventArgs)macroEvent.EventArgs;
                        MouseSimulator.MouseDown(mouseArgs.Button);
                    }
                    break;
                default:
                    break;
            }
        }
    }
