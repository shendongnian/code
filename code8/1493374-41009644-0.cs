        public dynamic Get()//your action
        {
            return JsonConvert.SerializeObject(new
            {
                templatevariables =
                new
                {
                    tabledata = new
                    {
                        Stationery_List_Details = new
                        {
                            Stationery_Item = "BLACK BOARD DUSTER",
                            Quantity = 5
                        }
                    }
                }
            });
        } 
