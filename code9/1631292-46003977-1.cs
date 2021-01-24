    switch (input.TypeId)
    {
        case 1:
              VoiceInput voiceInput = (VoiceInput)input.ObjectDefinesInput;
              return new VoiceResponse(voiceInput);
        default:
              TextInput textInput = (textInput)input.ObjectDefinesInput;
              return new TextResponse(textInput );
    }
   
