         akka {
                    serializers {
                      hyperion = ""Akka.Serialization.HyperionSerializer, Akka.Serialization.Hyperion""
                    }
                    serialization-bindings {
                      ""System.Object"" = hyperion
                    }
               .......
               .....
              }
