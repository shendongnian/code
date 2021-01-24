    private string _parameter = string.Empty;
    
    private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        switch(_parameter)
        {
            case string.Empty: 
            {
                switch (e.Result.Text)
                {                                     
                    case "setup": _parameter = "Name"; ...
                }
                break;
            }
            case "Name" : 
            { 
                sSynth.Speak("hello " + myName); 
                _parameter = "Age";
            }
            ...
        }
    }
