	public class SpeechToText_Android : Listener.ISpeechToText
	{
		public static AutoResetEvent autoEvent = new AutoResetEvent(false);
		public static string SpeechText;
		const int VOICE = 10;
		public async Task<string> SpeechToTextAsync()
		{
			var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
			voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
			voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Sprechen Sie jetzt");
			voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
			voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
			voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
			voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
			voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
			SpeechText = "";
			autoEvent.Reset();
			((Activity)Forms.Context).StartActivityForResult(voiceIntent, VOICE);
			await Task.Run(() => { autoEvent.WaitOne(new TimeSpan(0, 2, 0)); });
			return SpeechText;
		}
	}
