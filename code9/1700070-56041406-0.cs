using (var responseStream = response.GetResponseStream())
{
    using (var reader = new StreamReader(responseStream))
    {
        string line;
        while(responseStream.CanRead && (line = reader.ReadLine()) != null)
        {
            lines.Add(line);
        }
    }
}
