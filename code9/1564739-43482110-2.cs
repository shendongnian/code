    public async void DownloadDataAsync()
                {
                    try
                    {
                        string url = "http://myWebSite.com/jWebService.asmx/GetOffersJSON?storeID=2";
                        var httpClient = new HttpClient();
                        Task<string> downloadTask = httpClient.GetStringAsync(url);
                        string content = await downloadTask;
                    }
                    catch (Exception errorDownloadData)
                    {
                        Debug.WriteLine(errorDownloadData);
                        throw;
                    }
                try
                {
                    // de-serializing json response into list
                    // var content = "This XML file does not appear to have any style information associated with it.The document tree is shown below. <string xmlns = 'http://tempuri.org/' >[{ 'ItemID':20,'ItemBarcode':'111','ItemName':'hgh','ItemImage':'MegaOrders22017-04-14-08-34-27.jpg','ItemPrice':7.0000,'ItemNotes':'gffgdfj','OfferOn':true},{ 'ItemID':21,'ItemBarcode':'222','ItemName':'Nod','ItemImage':'MegaOrders22017-04-14-08-34-57.jpg','ItemPrice':4.0000,'ItemNotes':'kkkkkk','OfferOn':true},{ 'ItemID':22,'ItemBarcode':'333','ItemName':'kjkjkjkj','ItemImage':'MegaOrders22017-04-14-08-35-21.jpg','ItemPrice':6.0000,'ItemNotes':'hhhhggggg','OfferOn':true},{ 'ItemID':23,'ItemBarcode':'4444','ItemName':'oioioio','ItemImage':'MegaOrders22017-04-14-08-35-50.jpg','ItemPrice':5.0000,'ItemNotes':'hjhgfdfghj','OfferOn':true}]</string>";
                   var startPosition = response.IndexOf('>') + 1;
                   var endPosition = response.LastIndexOf("</", StringComparison.Ordinal);
                   var filteredResponseCharArray = new char[endPosition - startPosition];
                   content.CopyTo(startPosition, filteredResponseCharArray, 0, endPosition - startPosition);
                   var poi = JsonConvert.DeserializeObject<List<offers>>(new string(filteredResponseCharArray));
                }
                catch (Exception errorDeserializeData)
                {
                    Debug.WriteLine(errorDeserializeData);
                    throw;
                }
            }
