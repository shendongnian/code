    private async void speechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        if (e.Result.Grammar == placeholderGrammar)
        {
            //go to command mode
            placeholderGrammar.Enabled = false;
            dictationGrammar.Enabled = false;
            foreach (var item in commands)
                item.Enabled = true;
        }
        else if (commands.Any(x => e.Result.Grammar == x))
        {
            Do_something_with_that_ recognized_command("!!");
            
            //go back in normal mode
            placeholderGrammar.Enabled = true;
            dictationGrammar.Enabled = true;
        }else {//this is dictation.. nothing to do}
    }
