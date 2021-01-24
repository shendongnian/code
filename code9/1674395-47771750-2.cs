            foreach (IExampleInterface item in ExampleResults(0))
            {
                switch (item)
                {
                    case ExampleType c:
                        Response.Write(c.First.ToString());
                        Response.Write(c.Last.ToString());
                    case ExampleAmount c:
                        Response.Write(c.Amount.ToString());
                    default:
                        break;
                }
                //... And so on
            }
