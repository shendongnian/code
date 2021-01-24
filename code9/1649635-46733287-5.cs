    akka {
        loglevel = OFF
        
        actor {
          provider = "Akka.Remote.RemoteActorRefProvider, Akka.Remote"
          debug {
            receive = on
            autoreceive = on
            lifecycle = on
            event-stream = on
            unhandled = on
          }
        }
      
      
        remote {
          helios.tcp {
            transport-class = "Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote"  
            transport-protocol = tcp
            enforce-ip-family = true
            port = 0 //A port will be provided for us... not important as we won't be calling into the client externally
            public-hostname = "yoursitename.azurewebsites.net" //Remember this is simply the DNS name of the client machine
            hostname = "127.0.0.1"
          }
        }
      }
