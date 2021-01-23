         [TestMethod]
                public void TestMethod1()
                {
                    var path = Environment.GetFold`enter code here`erPath(Environment.SpecialFolder.Personal);
    // path = "C:\Users\pix\Documents"
                    using (var memoryStream = new MemoryStream())
                    {
                        var result = DownloadFile(memoryStream, path);
                        Assert.IsFalse(result);
                        result = DownloadFile(memoryStream, path + "test.text");
                        Assert.IsTrue(result);
                    }
                }
        
                private bool DownloadFile(Stream srcStream, string dstFile)
                {
                    bool success = false;
                    byte[] buffer = new byte[16384];
                    int byteCount;
                    FileStream destStream = null;
                    try
                    {
                        destStream = File.Create(dstFile);
                        while ((byteCount = srcStream.Read(buffer, 0, 16384)) != 0)
                        {
                            destStream.Write(buffer, 0, byteCount);
                        }
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        return success;
                    }
                    finally
                    {
                        try { destStream.Close(); }
                        catch (Exception) { }
                    }
        
                    return success;
                }
