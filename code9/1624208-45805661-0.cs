    public static async Task ConstructMessage(IDialogContext context, IMessageActivity msg)
    {
          switch (msg.ChannelId)
          {
                case "skypeforbusiness":
                    // Do Something Specific
                    break;
                case "emulator":
                case "skype":
                    break;
                case "msteams":
                    break;
                default:
                    break;
          }
    }
