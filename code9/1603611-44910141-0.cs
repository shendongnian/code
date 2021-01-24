    using (new OperationContextScope(client.InnerChannel))
    {
          var usernameHeader = MessageHeader.CreateHeader("username", string.Empty, _username);
          OperationContext.Current.OutgoingMessageHeaders.Add(usernameHeader);
          var passwordHeader = MessageHeader.CreateHeader("password", string.Empty, _passowrd);
          OperationContext.Current.OutgoingMessageHeaders.Add(passwordHeader);
          // some logic
    }
