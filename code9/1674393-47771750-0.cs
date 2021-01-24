            foreach (IExampleInterface item in ExampleResults(0))
            {
                if (item is ExampleType)
                {
                    var exampleType = (ExampleType)item;
                    Response.Write(exampleType.First.ToString())
                    Response.Write(exampleType.Last.ToString())
                }
                else if (item is ExampleAmount)
                {
                    var exampleAmount = (ExampleAmount)item;
                    Response.Write(exampleAmount.Amount.ToString())
              }
                //... And so on
            }
