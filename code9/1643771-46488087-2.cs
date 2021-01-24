    var txt = @"+----------------------------------------+-----------+
                |             Process Name               | PID       |
                +----------------------------------------+-----------+
                | securityAccessModule.exe               | 0x127F003A|
                | CMD.EXE                                | 0x77430012|
                | ps.exe                                 | 0x77010062|
                +----------------------------------------+-----------+";
    processes_checkedListBox.Font = new Font(new FontFamily("Consolas"), processes_checkedListBox.Font.Size);
    processes_checkedListBox.Items.Clear();
    string test = txt;
    var testArray = test.Split('\n');
    for (int i = 3; i < testArray.Length - 1; ++i)
    {
        string[] element = testArray[i].Split('|');
        element[1] = element[1].Trim();
        element[2] = element[2].Trim();
        processes_checkedListBox.Items.Add(string.Format("{0,-25} {1,-25}", element[1], element[2]), false);
    }
