      var FactorItem = context.FactorItems.Where(fi => fi.FactorRef == FactorID);
                    if (FactorItem!=null)
                    {
                        foreach (var item in FactorItem)
                        {
                            _FactorItems.FactorItemID = item.FactorItemID;
                            _FactorItems.FactorRef = item.FactorRef;
                            _FactorItems.PartCount = item.PartCount;
                            _FactorItems.PartPrice = item.PartPrice;
                            _FactorItems.PartRef = item.PartRef;
                            _FactorItems.Rowno = item.Rowno;
                            
                        }
                    }
