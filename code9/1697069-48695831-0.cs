     String FacebookURL = "https://www.facebook.com/dialog/oauth?client_id=" + FacebookClientID.Text + "&redirect_uri=" + Uri.EscapeUriString(FacebookCallbackUrl.Text) + "&scope=read_stream&display=popup&response_type=token";
    System.Uri StartUri = new Uri(FacebookURL);
    System.Uri EndUri = new Uri(FacebookCallbackUrl.Text);
    WebAuthenticationResult WebAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(
                                            WebAuthenticationOptions.None,
                                            StartUri,
                                            EndUri);
    if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
    {
        OutputToken(WebAuthenticationResult.ResponseData.ToString());
    }
    else if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
    {
        OutputToken("HTTP Error returned by AuthenticateAsync() : " + WebAuthenticationResult.ResponseErrorDetail.ToString());
    }
    else
    {
        OutputToken("Error returned by AuthenticateAsync() : " + WebAuthenticationResult.ResponseStatus.ToString());
    }
