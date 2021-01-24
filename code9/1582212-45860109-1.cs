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
