    private Dictonary<Control, string> speechTextDict = new Dictonary<Control, string>();
    
    private void SetupSpeechTexts() {
      this.speechTextDict.Add(this.button1, "First Text");
      this.speechTextDict.Add(this.button2, "Second Text");
      ...
    }
    
    private void button_click(object sender, EventArgs e) {
      Control senderControl = (Control)sender;
      if(this.speechTextDict.ContainsKey(senderControl)) {
        speaker.Speak(this.speechTextDict[senderControl]);
        speaker.Rate = -2;
        speaker.SelectVoiceByHints(VoiceGender.Female);
      }
    }
   
