    var stream = await response.Content.ReadAsStreamAsync();
        while (b == 1)
        { 
            var bytes = new byte[1];
            try
            {
                var bytesread = await stream.ReadAsync(bytes, 0, 1);
                if (bytesread > 0)
                {
                    text = Encoding.UTF8.GetString(bytes);
    
                    Console.WriteLine(text);
                    using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(@"C:\orden\ConSegu.txt", true))
                    {
                        if (ctext == 100)
                        {
                            escritor.WriteLine(text);
                            ctext = 0;
                        }
                        escritor.Write(text);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
                Console.WriteLine(ex.Message);
            }
        }
