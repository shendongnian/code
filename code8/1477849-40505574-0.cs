    public class DataItem
    {
        public string ItemNo { get; set; }
        public string ItemDesc { get; set; }
        public string Uom { get; set; }
        public string BalUnits { get; set; }
        public string BalLc { get; set; }
    }
    private IEnumerable<DataItem> GetItemsById(int customerId)
    {
        var queryItems = 
            from cd in  db.CDIndexes  
                join com in db.Companies on cd.cdin_CompanyId equals com.Comp_CompanyId
                join terr in db.Territories on cd.cdin_Secterr equals terr.Terr_TerritoryID
                join gds in db.Goods on cd.cdin_CDIndexID equals gds.good_CDIndexId
                join itms in db.Items on gds.good_ItemsID equals itms.item_ItemsID
                join capt in db.Custom_Captions on gds.good_UOM equals capt.Capt_Code
            where 
                capt.Capt_Family== "good_UOM" &&
                cd.cdin_Deleted == null &&
                cd.cdin_Status== "InProgress" &&
                cd.cdin_CompanyId==408 &&
                cd.cdin_CDIndexID== customerId && // Just use parameter instead of number
                itms.item_Deleted == null &&
                cd.cdin_GoodsProperty=="01" &&
                com.Comp_Deleted== null
            select new DataItem
                   {
                       ItemNo=itms.item_itemNo,
                       ItemDesc=itms.item_Name,
                       Uom=capt.Capt_US,
                       BalUnits=gds.good_RemainWT,
                       BalLc=gds.good_BalanceAmtLC,
                   };        
    }
