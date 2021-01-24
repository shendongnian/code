    public class MainActivity : Activity, IRecognitionListener
    {
        private TextView tv;
        private SpeechRecognizer sr;
    
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
    
            sr = SpeechRecognizer.CreateSpeechRecognizer(this);
            sr.SetRecognitionListener(this);
    
            Button btn = FindViewById<Button>(Resource.Id.btn);
            btn.Click += (sender, e) =>
            {
                Intent intent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
                intent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
                intent.PutExtra(RecognizerIntent.ExtraCallingPackage, "this package");
                intent.PutExtra(RecognizerIntent.ExtraMaxResults, 5);
                sr.StartListening(intent);
            };
    
            tv = FindViewById<TextView>(Resource.Id.tv);
        }
    
        public void OnBeginningOfSpeech()
        {
            tv.Text = "Beginning";
        }
    
        public void OnBufferReceived(byte[] buffer)
        {
        }
    
        public void OnEndOfSpeech()
        {
        }
    
        public void OnError([GeneratedEnum] SpeechRecognizerError error)
        {
            tv.Text = error.ToString();
        }
    
        public void OnEvent(int eventType, Bundle @params)
        {
        }
    
        public void OnPartialResults(Bundle partialResults)
        {
        }
    
        public void OnReadyForSpeech(Bundle @params)
        {
            tv.Text = "Ready!";
        }
    
        public void OnResults(Bundle results)
        {
            var data = results.GetStringArrayList(SpeechRecognizer.ResultsRecognition);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Count; i++)
            {
                builder.Append(data[i]);
            }
            tv.Text = builder.ToString();
        }
    
        public void OnRmsChanged(float rmsdB)
        {
        }
    }
