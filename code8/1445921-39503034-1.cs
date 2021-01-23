      await this.Options.Provider.ValidateClientRedirectUri(clientContext);
      if (!clientContext.IsValidated)
      {
        LoggerExtensions.WriteVerbose(this._logger, "Unable to validate client information");
        flag = await this.SendErrorRedirectAsync(clientContext, (BaseValidatingContext<OAuthAuthorizationServerOptions>) clientContext);
      }
      else
      {
        OAuthValidateAuthorizeRequestContext validatingContext = new OAuthValidateAuthorizeRequestContext(this.Context, this.Options, authorizeRequest, clientContext);
        if (string.IsNullOrEmpty(authorizeRequest.ResponseType))
        {
          LoggerExtensions.WriteVerbose(this._logger, "Authorize endpoint request missing required response_type parameter");
          validatingContext.SetError("invalid_request");
        }
        else if (!authorizeRequest.IsAuthorizationCodeGrantType && !authorizeRequest.IsImplicitGrantType)
        {
          LoggerExtensions.WriteVerbose(this._logger, "Authorize endpoint request contains unsupported response_type parameter");
          validatingContext.SetError("unsupported_response_type");
        }
        else
          await this.Options.Provider.ValidateAuthorizeRequest(validatingContext);
        if (!validatingContext.IsValidated)
        {
          flag = await this.SendErrorRedirectAsync(clientContext, (BaseValidatingContext<OAuthAuthorizationServerOptions>) validatingContext);
        }
        else
        {
          this._clientContext = clientContext;
          this._authorizeEndpointRequest = authorizeRequest;
          OAuthAuthorizeEndpointContext authorizeEndpointContext = new OAuthAuthorizeEndpointContext(this.Context, this.Options, authorizeRequest);
          await this.Options.Provider.AuthorizeEndpoint(authorizeEndpointContext);
          flag = authorizeEndpointContext.IsRequestCompleted;
        }
      }
