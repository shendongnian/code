    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            switch ((ResourceKind)item["ResourceKind"].Value<int>())
            {
                case ResourceKind.ACTIVITY:
                    return item.ToObject<AppointedActivity>();
                case ResourceKind.CONSUMABLE:
                    return item.ToObject<AppointedConsumable>();
                case ResourceKind.DEVICE:
                    return item.ToObject<AppointedDevice>();
                default:
                    throw new Exception("Invalid ResourceType");
            }
        }
