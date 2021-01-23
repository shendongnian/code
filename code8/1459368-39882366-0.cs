    bool alarmTriggered = false;
    private void WakeUpProcess()
    {
        StreamReader CurrentAgenda = new StreamReader("C:/Users/Max/documents/visual studio 2015/Projects/Advanced_AlarmClock/Advanced_AlarmClock/File Resources/Todays Agenda.txt");
        TimeSpan start = new TimeSpan(06, 50, 0); //10 o'clock
        TimeSpan end = new TimeSpan(07, 00, 0); //12 o'clock
        TimeSpan now = DateTime.Now.TimeOfDay;
        System.IO.StreamReader CurrentAgendaRaw = new System.IO.StreamReader("C:/Users/Max/documents/visual studio 2015/Projects/Advanced_AlarmClock/Advanced_AlarmClock/File Resources/Todays Agenda.txt");
        string CurrentAgendaTxt = CurrentAgendaRaw.ReadToEnd();
    
        if ((now > start) && (now < end) && !alarmTriggered)
        {
            alarmTriggered = true;
            this.WindowState = FormWindowState.Normal;
            Output.Text = ("Good Morning Max" + Environment.NewLine + CurrentAgendaTxt);            
            Process.Start("C:/Users/Max/Downloads/Juice Newton - Angel Of The Morning.mp3");
    
            }
        }
        else {
            alarmTriggered = false;
        }
    
    }
