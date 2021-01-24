    async Task<HttpStatusCode> PutProduct(Product product,HttpClient client)
    {
               var response=await client.PutAsJsonAsync($"api/products/{product.Id}", product);
               if (!response.IsSuccessStatusCode)
               {
                   //Log the error                  
               }
               return response.StatusCode;
     };
     var callTasks = myProducts.Select(product=>PutProductAsync(product));
     var responses=await Task.WhenAll(callTasks);
