    public override nfloat GetMessageBubbleTopLabelHeight (MessagesCollectionView collectionView, MessagesCollectionViewFlowLayout collectionViewLayout, NSIndexPath indexPath)
		{
			Message message = Messages [indexPath.Row];
			if (message.SenderId == Sender.UserId.ToString())
				return 0.0f;
			if (indexPath.Row - 1 >= 0) {
				Message previousMessage = Messages [indexPath.Row - 1];
				if (previousMessage.SenderId == message.SenderId)
					return 0.0f;
			}
			return 20.0f;
		}
