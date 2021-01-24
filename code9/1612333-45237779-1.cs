    private void Toast()
    {
        var visual = new ToastVisual
        {
            BindingGeneric = new ToastBindingGeneric
            {
                Children =
                {
                    new AdaptiveText
                    {
                        Text = "title"
                    },
                    new AdaptiveText
                    {
                        Text = "content"
                    }
                }
            }
        };
        var toastContent = new ToastContent
        {
            Visual = visual,
            Launch = new QueryString
            {
                { "action", "viewConversation" },
                { "conversationId", "id" }
            }.ToString()
        };
        var toast = new ToastNotification(toastContent.GetXml());
        ToastNotificationManager.CreateToastNotifier().Show(toast);
    }
