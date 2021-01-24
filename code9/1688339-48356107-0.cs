      The orginal code in the file is 
      stream.AuthenticateAsClient(this.appleSettings.Host, this.certificates, System.Security.Authentication.SslProtocols.Ssl3, false);
     replace it with 
     stream.AuthenticateAsClient(this.appleSettings.Host, this.certificates, System.Security.Authentication.SslProtocols.Tls, false);					
  		
