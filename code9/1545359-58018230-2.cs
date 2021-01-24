csharp
[HttpDelete]
public void Content()
{
    Response.StatusCode = 200;
    Response.ContentType = "text/html";
    // the easiest way to implement a streaming response, is to simply flush the stream after every write.
    // If you are writing to the stream asynchronously, you will want to use a Synchronized StreamWriter.
    using (var sw = StreamWriter.Synchronized(new StreamWriter(Response.Body)))
    {
        foreach (var item in new int[] { 1, 2, 3, 4, })
        {
            Thread.Sleep(1000);
            sw.Write($"<p>Hi there {item}!</p>");
            sw.Flush();
        }
    };
}
you can test with curl using the following command: `curl -NX DELETE <CONTROLLER_ROUTE>/content`
