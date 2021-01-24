    foreach (var sri in searchResultItems)
                    {
                        // Get all child xml elements
                        var childElements = sri.Elements();
    
                        var itemId = childElements.FirstOrDefault(x => x.Name.LocalName == "itemId");
                        var imageurl = childElements.FirstOrDefault(x => x.Name.LocalName == "galleryURL");
                        var title = childElements.FirstOrDefault(x => x.Name.LocalName == "title");
                        var url = childElements.FirstOrDefault(x => x.Name.LocalName == "viewItemURL");
                        var nofwatch = childElements.FirstOrDefault(x => x.Name.LocalName == "listingInfo").Elements().FirstOrDefault(x => x.Name.LocalName == "watchCount");
    
                        //add items from xml data to EbayDataViewModel object
                        items.Add(new EbayDataViewModel
                        {
                            ItemId = itemId == null ? String.Empty : itemId.Value,
                            EbayImageUrl = imageurl == null ? String.Empty : imageurl.Value,
                            EbayTitle = title == null ? String.Empty : title.Value,
                            EbayUrl = url == null ? String.Empty : url.Value,
                            NumberOfWatch = nofwatch == null ? String.Empty : nofwatch.Value,
                        });
                    }
