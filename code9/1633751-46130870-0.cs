    using UnityEngine;
    using System.Collections;
    using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
    
    public class AudioClipToTextWatson : MonoBehaviour {
        // Non-streaming
        SpeechToText m_SpeechToText = new SpeechToText();
        public AudioClip m_AudioClip = new AudioClip();
        public bool on = false;
       
        void Start () {
            m_AudioClip = Microphone.Start(Microphone.devices[0], false, 4, 44100);
      
                m_SpeechToText.Recognize(m_AudioClip, OnRecognize);
                //  Streaming
                m_SpeechToText.StartListening(OnRecognize);
                //  Stop listening
                m_SpeechToText.StopListening();
        }
    
    
        private void OnRecognize(SpeechRecognitionEvent result)
        {
            Debug.Log("result : " + result);
            if (result != null && result.results.Length > 0)
            {
                foreach (var res in result.results)
                {
                    foreach (var alt in res.alternatives)
                    {
                        string text = alt.transcript;
                        Debug.Log(text);
                        Debug.Log(res.final);
                    }
                }
            }
        }
    
    }
