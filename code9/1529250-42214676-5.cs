    public static class ServiceHelper {
      /// <summary>
      /// Disposes the given service.
      /// </summary>
      /// <param name="service">The service.</param>
      public static void DisposeService(ICommunicationObject service) {
         if( service != null ) {
            bool abort = true;
            try {
               if( service.State == CommunicationState.Opened || service.State == CommunicationState.Opening ) {
                  service.Close();
                  abort = false;
               }
            }
            finally {
               // Determine if we need to Abort the communication object.
               if( abort )
                  service.Abort();
            }
         }
      }
