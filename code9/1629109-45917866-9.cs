             List<Entry> list; // This list contains the commands
                
                public SomeClass() {
                list = new List<Entry>(); // initializion of the list in the constructor
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
     case "do not confirm command": 
                list.Add(new Entry() { Cmd = Command.No });
                verifyList();
                break;
                }
                }
            
        // This class holds all important stuff of one command. 
        // 1. The kind of command
        // 2. the action that performs if condition in verifyList() are true
        // 3. And NeedConfirm that the verifiyList() needs
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
