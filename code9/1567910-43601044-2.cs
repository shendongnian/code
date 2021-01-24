     using (var client = new HttpClient())
                {
                    string URI = string.Format("http://localhost:14456/api/serious/updtTM");
                    file f1 = new file();
    
                    byte[] aa = File.ReadAllBytes(@"D:\Capture2.PNG");
             
                    f1.str = aa;
                    f1.filename = "Capture2";
                    f1.contentType = "PNG";
                    var serializedProduct = JsonConvert.SerializeObject(f1); 
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(URI, content).Result;
                }
