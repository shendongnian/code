     dataSourceToBind.ForEach(x =>
            {
                var innerList = x;
                innerList.ForEach(y =>
                {
                    if (y.ReceiptRowCategory == "Payment")
                    {
                        y.ReceiptItemFor = null;
                        y.ReceiptItemCategory = null;
                    }
                });
            });
