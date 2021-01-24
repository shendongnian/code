    using Client.Photon.LoadBalancing;
    using UnityEngine;
    using UnityEngine.UI;
    [RequireComponent(typeof(Button))]
    public class PushToTalkPrivateButton : MonoBehaviour
    {
        [SerializeField]
        private Button pushToTalkPrivateButton;
        [SerializeField]
        private Text buttonText;
        private PushToTalkScript pttScript;
        public byte AudioGroup;
        public bool Subscribed;
    
        private void Start()
        {
            pttScript = FindObjectOfType<PushToTalkScript>();
            PhotonVoiceNetwork.Client.OnStateChangeAction += OnVoiceClientStateChanged;
        }
    
    
        private void OnVoiceClientStateChanged(ClientState state)
        {
            Debug.LogFormat("VoiceClientState={0}", state);
            if (pushToTalkPrivateButton != null)
            {
                switch (state)
                {
                    case ClientState.Joined:
                        //Subscribed = Subscribed || PhotonVoiceNetwork.Client.ChangeAudioGroups(null, new byte[1] { AudioGroup });
                        break;
                    default:
                        pushToTalkPrivateButton.gameObject.SetActive(false);
                        PhotonVoiceNetwork.Client.ChangeAudioGroups(byte[0], null);
                        break;
                }
            }
        }
    
        public void SetAudioGroup(PhotonPlayer player)
        {
            if (!Subscribed)
            {
                buttonText.text = string.Format("Talk-To-Player{0}", player.ID);
                int targetActorNr = player.ID;
                if (PhotonNetwork.player.ID < targetActorNr)
                {
                    AudioGroup = (byte) (targetActorNr + PhotonNetwork.player.ID*10);
                }
                else if (PhotonNetwork.player.ID > targetActorNr)
                {
                    AudioGroup = (byte) (PhotonNetwork.player.ID + targetActorNr*10);
                }
                else
                {
                    return;
                }
                if (PhotonVoiceNetwork.ClientState == ClientState.Joined)
                {
                    pushToTalkPrivateButton.gameObject.SetActive(true);
                    Subscribed = PhotonVoiceNetwork.Client.ChangeAudioGroups(null, new byte[1] { AudioGroup });
                }
            }
        }
    
        public void PushToTalkOn()
        {
            if (Subscribed)
            {
                PhotonVoiceNetwork.Client.GlobalAudioGroup = AudioGroup;
                pttScript.PushToTalk(true);
            }
        }
    
        public void PushToTalkOff()
        {
            pttScript.PushToTalkOff();
        }
    }
