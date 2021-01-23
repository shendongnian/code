		const int VOICE = 10;
		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (requestCode == VOICE)
			{
				if (resultCode == Result.Ok)
				{
					var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
					if (matches.Count != 0)
					{
						var textInput = matches[0];
						if (textInput.Length > 500)
							textInput = textInput.Substring(0, 500);
						SpeechToText_Android.SpeechText = textInput;
					}
				}
				SpeechToText_Android.autoEvent.Set();
			}
		}
