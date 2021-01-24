    String url="https://www.ah.nl/service/rest/delegate?url=%2Fproducten%2Fproduct%2Fwi224735%2Fdoritos-nacho-cheese&_=1513938720642";
    System.Net.WebClient client=new System.Net.WebClient();
    String json = client.DownloadString(url);
    System.IO.File.WriteAllText("fileName.json",json);
    Console.WriteLine(json);
