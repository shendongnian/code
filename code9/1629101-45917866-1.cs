    List<Entry> list;
    
    public SomeClass() {
    list = new List<Entry>();
    }
    
    private void verifyList() {
    if (list.Count == 0)
    return;
    
    if (list[0].Cmd == Command.Yes || list[0].Cmd == Command.No) {
    list.Clear();
    } else if (!list[0].NeedConfirm || (list.Count == 2 && list[1].Cmd == Command.Yes)) {
    list[0].Call?.Invoke();
    list.Clear();
    } else if (list.Count >= 2) {
    list.Clear();
    }
    }
    
    private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        switch (e.Result.Text)
        {                
            case "hey computer, start spotify":
    list.Add(new Entry() { Cmd = Command.Yes, Call = new Action(() => {
    // start spotify
    }) });
    verifyList();
                break;
            case "confirm command": 
    list.Add(new Entry() { Cmd = Command.Yes });
    verifyList();
    break;
    }
    }
    
    public class Entry {
    Command Cmd;
    Action Call;
    bool NeedConfirm;
    }
    
    public enum Command {
    StartSpotify,
    Yes,
    No
    }
