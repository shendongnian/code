        private class JsonModel
        {
            public string Version { get; set; }
            public IList<JsonBillModel> BillLists { get; set; } = new List<JsonBillModel>();
        }
        private class JsonBillModel
        {
            public string UserGstin { get; set; }
            public string SupplyType { get; set; }
            public int SubSupplyType { get; set; }
            public string DocType { get; set; }
            //...
        }
