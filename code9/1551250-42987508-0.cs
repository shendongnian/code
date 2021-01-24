    if (speech = "CALL MARK) {
        var string input = Api.DetectSpeech(Source.Microphone);
        if (input = "YES") {
            Phone.DialNumber(Contacts.Mark);
        }
    }
