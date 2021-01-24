    var response = client.DescribeSubnets(new DescribeSubnetsRequest 
    {
        Filters = new List<filter> {
            new Filter {
                Name = "vpc-id",
                Values = new List<string> {
                    "vpc-a01106c2"
                }
            }
        }
    });
     
    List<subnet> subnets = response.Subnets;
