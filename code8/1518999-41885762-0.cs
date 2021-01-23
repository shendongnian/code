       public ActionResult AddNewAsset(AssetHeaderDetails entity)
        {
            if (IsExist<Supplier>(entity.SupplierDetails))
            {
                entity.SupplierId = entity.SupplierDetails.Id;
                entity.SupplierDetails = null;
            }
            AddDataToContext(entity);
            AddToLookUp("AssetItemDesc", entity.Description,     entity.Description);
            if(entity.AssetItemDetails != null)
            {
                foreach (var item in entity.AssetItemDetails)
                {
                    AddToLookUp("AssetItemDetail", item.ItemDescription, item.ItemType);
                }
            }
            return RedirectToAction("AddNewAsset");
        }
