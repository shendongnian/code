            bool hasAVModality = e.Conversation.Modalities.ContainsKey(ModalityTypes.AudioVideo);
            if (hasAVModality)
            {
                //State of AV modality
                var state = e.Conversation.Modalities[ModalityTypes.AudioVideo].State;
                //Notified = Incoming
                if (state == ModalityState.Notified)
                {
			        //Do Something with the call
		        }
            }
