csharp
[HttpDelete]
public void Content()
{
    Response.StatusCode = 200;
    Response.ContentType = "text/html";
    // the easiest way to implement a streaming response, is to simply open a new stream writer every time
    // you have new data to write. When the writer is closed, the data will be sent to the client.
    foreach (var item in new int[] { 1, 2, 3, 4, })
    {
        using (var sw = new StreamWriter(Response.Body))
        {
            Thread.Sleep(1000);
            sw.Write($"<p>Hi there {item}!</p>");
        }
    };
}
you can test with curl using the following command: `curl -NX DELETE <CONTROLLER_ROUTE>/content`
