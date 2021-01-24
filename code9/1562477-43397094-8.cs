    FB.AppRequest(
            string message,
            IEnumerable<string> to = null,
            IEnumerable<object> filters = null,
            IEnumerable<string> excludeIds = null,
            int? maxRecipients = null,
            string data = "",
            string title = "",
            FacebookDelegate<IAppRequestResult> callback = null);
