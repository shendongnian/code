    private static Dictionary<string, string> soundDictionary = 
        new Dictionary<string, string>();
    private static void LoadDictionary()
    {
        soundDictionary.Add("a", "A as in apple.");
        soundDictionary.Add("b", "B as in banana.");
    }
    private void PlaySound_Click(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var letter = button.Tag;
        speaker.Rate = -2;
        speaker.SelectVoiceByHints(VoiceGender.Female);
        speaker.Speak(dictionary[letter]);
    }
