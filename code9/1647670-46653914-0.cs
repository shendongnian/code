    public static class MessageBuilderExtensions {
        public static IMessageBuilder AddToRecipients(
            this IMessageBuilder builder
        ,   IEnumerable<IRecipient> recipients
        ,   JObject recipientVariables = null) {
            foreach (var recipient in recipients) {
                builder = builder.AddRecipient(recipient, recipientVariables);
            }
            return builder;
        }
    }
