    using (var stream = File.OpenWrite(@"c:\prueba\localtest.pdf"))
    {
        Console.WriteLine(await response.GetContentAsStringAsync());
        var dataToWrite = await response.GetContentAsByteArrayAsync();
        stream.Write(dataToWrite, 0, dataToWrite.Length);
        Console.ReadKey();
    }
