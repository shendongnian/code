    var receipt = await db.Receipts
            .Where(r => r.receiptId.Equals(receiptId))
            .Select(r => new
                {
                    r.receiptId,
                    r.receiptDate,
                    r.supplierId,
                    r.Supplier.supplierName,
                    ReceiptItems = r.ReceiptItems
                                        .Select(ReceiptItem => new
                                            {
                                            ReceiptItem.itemId,
                                            ReceiptItem.Item.itemName,
                                            ReceiptItem.itemPackage,
                                            ReceiptItem.itemQnty,
                                            ReceiptItem.itemCost
                                            }
                                        )
                }
            )
           .FirstOrDefaultAsync();
