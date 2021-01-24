    //Get a response
                    IRestResponse<RootObject> searchResponse = client.Execute<RootObject>(searchRequest);
    
                    var hotelList = searchResponse.Data.HotelListResponse.HotelList.HotelSummary.ToArray();
    
                    foreach (var hotelSummary in hotelList.ToArray())
                    {
                        GridViewResults.DataSource = hotelList;
                        GridViewResults.DataBind();
                    }
