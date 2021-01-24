    items.ToList().ForEach(item =>
                        {
                        var attr = item.ItemAttributeValues.ToList().Where(x => x.AttributeNm == "EST" && x.StatusNm == "SAP").FirstOrDefault();
                        item.ItemAttributeValues.Remove(attr);
                        }
                    );
