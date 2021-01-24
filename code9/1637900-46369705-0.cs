    public class ExampleClass : MonoBehaviour {
        public WebCamTexture webcamTexture;
        public Color32[] data;
        private string _apikey = "<api>";
        private string _url = "https://gateway-a.watsonplatform.net/visual-recognition/api";
        private VisualRecognition _visualRecognition;
        private string _visualRecognitionVersionDate = "2016-05-20";
        void Start() 
        {
            //  Instantiate Visual Recognition service
            Credential credential = new Credential(_apikey, _url);
            _visualRecognition = new VisualRecognition();
            _visualRecognition.VersionDate = _visualRecognitionVersionDate;
            
            //  Init the WebCamTexture and byte data
            webcamTexture = new WebCamTexture();
            webcamTexture.Play();
            data = new Color32[webcamTexture.width * webcamTexture.height];
            //  Send data to service
            if (!_visualRecognition.Classify(OnClassify, data))
                Log.Debug("ExampleVisualRecognition", "Classify image failed!");
        }
        void Update()
        {
            //  Get bytearray data from webcam every frame
            webcamTexture.GetPixels32(data);
        }
        private void OnClassify(ClassifyTopLevelMultiple classify, string data)
        {
            //  Print classify response
            Log.Debug("Webcam example", "response: {0}", data);
        }
    }
