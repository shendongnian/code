	foreach (var voice in NSSpeechSynthesizer.AvailableVoices)
	{
		Console.WriteLine(voice);
		var attributes = NSSpeechSynthesizer.AttributesForVoice(voice);
		foreach (var item in attributes)
		{
			if (item.Key.ToString() == "VoiceIndividuallySpokenCharacters" ||
				item.Key.ToString() == "VoiceSupportedCharacters")
				continue;
			Console.WriteLine($"\t{item.Key}:{item.Value}");
		}
		Console.WriteLine();
	}
