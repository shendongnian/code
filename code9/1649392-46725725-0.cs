    var callTasks = myProducts.Select(async product=>{
           var response=await client.PutAsJsonAsync($"api/products/{product.Id}", product);
           if (!response.IsSuccessStatusCode)
           {
               //Log the error                  
           }
           return response.StatusCode;
    });
    var responses=await Task.WhenAll(callTasks);
