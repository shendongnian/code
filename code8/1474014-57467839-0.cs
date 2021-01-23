c#
[HttpGet]
public IEnumerable<string> Get()
{
    return GetStringsFor(10000);
}
private static readonly Random random = new Random();
private IEnumerable<string> GetStringsFor(int amount)
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    while (amount-- > 0)
    {
        yield return new string(Enumerable.Repeat(chars, random.Next(1000)).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
This will ensure that not everything is loaded into memory, but sent on demand. You would be able to implement something similar in your case when you're reading to data into memory, because that is one time where the system could just start sending the result instead.
c#
private IEnumerable<BearingTemperature> ReadTemperatures(SqlDataReader reader)
{
    if (reader.HasRows)
    {
        var bt = new BearingTemperature();
        while (reader.Read())
        {
            bt.Time = reader.GetDateTime(1);
            bt.Turbine = reader.GetInt32(0);
            bt.Value = reader.GetDouble(2);
            yield return bt;
    }
    yield break;
}
[HttpGet("{turbine:int}")]
public IEnumerable<BearingTemperature> GetBearingTemperature(int turbine)
{
    using (var connection = Database.GetConnection())
    {
        <snip>
        var reader = command.ExecuteReader();
        return ReadTemperatures(reader);
    }
}
