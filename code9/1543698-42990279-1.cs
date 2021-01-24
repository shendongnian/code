        [TestMethod]
        public void TestPatch()
        {
            var client = ArcoCloud.Gateway.Client.Runtime.GetGatewayClient();
            var changeTracker = new Microsoft.OData.Client.DataServiceCollection<ArcoCloud.Gateway.Client.ArcoCloud_DataModel.Device>(client.Devices);
            // just change device 96
            var device = changeTracker.Single(d => d.Id == 96);
            device.Notes = "This is a test note to check if patch works natively";
            client.SaveChanges();
            /* Traced in Fiddler4
            PATCH: {
              "@odata.type": "#ArcoCloud_DataModel.Device",
              "Notes": "This is a test note to check if patch works natively"
            }*/
        }
