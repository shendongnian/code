            [XmlIgnore]
            public List<object> Things
            {
                get
                {
                    var ret = new List<object>();
                    if (PurchaseOrderNumber != null)
                        ret.Add(PurchaseOrderNumber);
                    if (OrderDate != null)
                        ret.Add(OrderDate);
                    if (DeliveryNotes != null)
                        ret.Add(DeliveryNotes);
                    if(Cars != null)
                        ret.AddRange(Cars);
                    if(Address != null)
                        ret.Add(Address);
                    return ret;
                }
            }
