    var client = new ...;
    try {
       // Do work
       // Everything went well so close the client
       client.Close();
    }
    catch( Exception ex ) {
       // Something went wrong so call abort
       client.Abort();
       // Other logging code 
    }
    
    if( client.State != System.ServiceModel.CommunicationState.Closed ) {
       client.Close();
    }
