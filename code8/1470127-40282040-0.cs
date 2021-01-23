        public void GetCollectionTest2()
        {
            var con = this.scomService.Connect(Server, UserName, Password);
            string query = "select * from SMS_ObjectContainerItem  where ContainerNodeID = '16777219'";
            IResultObject packages = con.QueryProcessor.ExecuteQuery(query);
            foreach (IResultObject ws in packages)
            {
                Debug.Print(ws["InstanceKey"].StringValue);
                
                string query2 = "SELECT * FROM SMS_Collection WHERE CollectionID='"+ ws["InstanceKey"].StringValue +"'";
                //// Run query.
                IResultObject colResultObject = con.QueryProcessor.ExecuteQuery(query2);
                foreach (IResultObject ws2 in colResultObject)
                {
                    Debug.Print(ws2["Name"].StringValue);
                }
            }
        }
