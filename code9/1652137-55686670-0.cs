public readonly struct UserId
{
  public static readonly UserId Empty = new UserId();
  public UserId(int value)
  {
    Value = value;
    HasValue = true;
  }
  public int Value { get; }
  public bool HasValue { get; }
}
I've got this struct, which is backed by an `int`. I want to deserialize a specific JSON `number` value as an `int` -> `UserId`. So, I create a custom converter:
public class UserIdConverter
{
  public override bool CanConvert(Type objectType) => objectType == typeof(UserId);
  
  public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
  {
    int? id = serializer.Deserialize<int?>(reader);
    if (!id.HasValue)
    {
      return UserId.Empty;
    }
    
    return new UserId(id.Value);
  }
}
> I've skipped over the implementation of `WriteJson` in this instance, but the logic is the same.
I would write my test as follows:
[Fact]
public void UserIdJsonConverter_CanConvertFromJsonNumber()
{
    // Arrange
    var serialiser = new JsonSerializer();
    var reader = CreateJsonReader("10");
    var converter = new UserIdJsonConverter();
    // Act
    var result = converter.ReadJson(reader, typeof(UserId), null, serialiser);
    // Assert
    Assert.NotNull(result);
    Assert.IsType<UserId>(result);
    var id = (UserId)result;
    Assert.True(id.HasValue);
    Assert.Equal(10, id.Value);
}
private JsonTextReader CreateJsonReader(string json)
    => new JsonTextReader(new StringReader(json));
In doing so, I can create a test purely around my `ReadJson` method, and confirm it does what I expect. *Going further*, I could potentially mock elements, such as the `JsonReader` and `JsonSerializer` to result in different preconditions so I can test a wide array of scenarios.
The issue with relying on `JsonConvert` or `JsonSerializer` to run the full deserialization process, is that you're introducing other logic which is largely outside of your control. I.e., what if through deserialization, JSON.NET actually makes a different decision and your custom converter is never used - your test isn't responsible for testing JSON.NET itself, but what your custom converter actually does.
