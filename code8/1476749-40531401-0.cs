    public static async Task<SwipeDetails> SaveSwipesToCloud() {
        //get unuploaded swips
        var swipesnotsved =  SwipeRepository.GetUnUploadedSwipes();
    
        foreach (var item in swipesnotsved) {
            //send it to the cloud
            var uri = new Uri(URL + "SaveSwipeToServer");
            //create the parameteres
            var data = new Dictionary<string, string>();
            data["locationId"] = item.LocationID;
            data["userId"] = item.AppUserID;
            data["ebCounter"] = item.SwipeID;
            data["dateTimeTicks"] = item.DateTimeTicks;
            data["swipeDirection"] = item.SwipeDirection;
            data["serverTime"] = item.IsServerTime;
    
            var body = new System.Net.Http.FormUrlEncodedContent(data);
    
            var client = new HttpClient();
    
            var response = await client.PostAsync(uri, body);
            
            //the content needs to update the record in the SwipeDetails table to say that it has been saved.
            var content = await response.Content.ReadAsStringAsync();            
        }
        return null;
    }
