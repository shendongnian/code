            using (var E_Shop_DB_Obj = new Model())
            {
                var item = E_Shop_DB_Obj.DevicesInfo_Tbl.FirstOrDefault(a => a.Id == index);
                // Test if item is not null
                E_Shop_DB_Obj.DevicesInfo_Tbl.Remove(item);
                E_Shop_DB_Obj.SaveChanges();
            }
