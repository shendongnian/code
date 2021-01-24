    [WebMethod]
    public CheckPolicyMessage CheckPolicy(string PolicyNumber, string PolicyMod)
    {
      CheckPolicyMessage msg = new CheckPolicyMessage();
      ...
      // set the msg properties in all of your case statements, note, you have 
      // one treated as an exception case (Policy Exist) but doesn't appear that you 
      // communicate it back to the user.
      msg.Code = "???";
      msg.Message = "Some message you want to display here";
      ...
      return msg;
    }
