    if (response.IsSuccessStatusCode){
    string strJson = response.Content.ReadAsStringAsync().Result;
    Console.WriteLine(strJson);
    Person person = JsonConvert.DeserializeObject<Person>(strJson);    
    }
   
