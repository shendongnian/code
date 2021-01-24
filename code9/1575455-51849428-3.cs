     public JsonResult OnGetPopulateLineItemRow(string _asset)
        {
            //stores named value pairs for the result
            Dictionary<string, string> results = new Dictionary<string, string>();
            //get record from the database for the specified asset (_asset)
            var asset = from a in _context.Asset select a;
            asset = asset.Where(a => a.Asset1 == _asset); 
            //get value for each field
            var description1 = from d in asset select d.AssetDescription;
            var description2 = from d in asset select d.AssetDescription2;
            var inventoryNum = from d in asset select d.InventoryNo;
            var serialNum = from s in asset select s.SerialNo;
            //add the name value pairs to the collection
            results.Add("description1", description1.ToList()[0].ToString());
            results.Add("description2", description2.ToList()[0].ToString());
            results.Add("inventoryNum", inventoryNum.ToList()[0].ToString());
            results.Add("serialNum", serialNum.ToList()[0].ToString());
            return new JsonResult(results);
        }
