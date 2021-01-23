    string buttonName = ((Button)sender).Name;
    string speechText = string.Empty;
    if (buttonName == "Button1"))
    { 
      speechText = "A as in apple";
    } else if
    ...
    speaker.Speak(speechText );
    speaker.Rate = -2;
    speaker.SelectVoiceByHints(VoiceGender.Female);
