    var itemRef = itemRepository.Get(i => i.ItemID == orderItem.ItemID).FirstOrDefault();
    if (itemRef != null) {
        //Line Sales Item Line Detail - ItemRef
        lineSalesItemLineDetail.ItemRef = new ReferenceType() {
            Name = itemRef.FullDescription,
            Value = itemRef.ItemID 
        };
    }
