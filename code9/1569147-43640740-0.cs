               if ((start != null && end != null))
                {
                    if (IncludeClosedQuotes == true && quotes1.QuoteStatus != null)
                    {
                        if((ExcludeNoBid == false) && ((String.IsNullOrEmpty(ProductCode)) || (quotes1.ProductCode != ProductCode)))
                        {
                            myList.Add(quotes1);
                        }
                        if ((ExcludeNoBid == false) && (quotes1.ProductCode == ProductCode) && (quotes1.SalesCode.ToString() == SalesPerson))
                        {
                            myList.Add(quotes1);
                        }
                         
                        if ((ExcludeNoBid == true && quotes1.NoBid == false) && (quotes1.ProductCode == ProductCode))
                        {
                            myList.Add(quotes1);
                        }
                        if((ExcludeNoBid == true && quotes1.NoBid == false) && (quotes1.ProductCode != ProductCode) && (quotes1.SalesCode.ToString() != SalesPerson))
                        {
                             myList.Add(quotes1);
                        }
                    }
                    
                    if ((IncludeClosedQuotes == false) && (ExcludeNoBid == false))
                    {
                        if (quotes1.ProductCode == ProductCode)
                        {
                            myList.Add(quotes1);
                        }
                        if ((quotes1.ProductCode == ProductCode) && (quotes1.SalesCode.ToString() == SalesPerson))
                        {
                            myList.Add(quotes1);
                        }
                    }
                    if ((IncludeClosedQuotes == false) && (ExcludeNoBid == true && quotes1.NoBid == false))
                    {
                        if ((quotes1.ProductCode == ProductCode) && (quotes1.SalesCode.ToString() != SalesPerson))
                        {
                            myList.Add(quotes1);
                        }
                        if((String.IsNullOrEmpty(ProductCode) && quotes1.SalesCode.ToString() == SalesPerson))
                        {
                            myList.Add(quotes1);
                        }
                    }
              }
