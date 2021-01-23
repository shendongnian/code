    var messageTypeToTypeMap = new Dictionary<string, Func<BaseBaseRuleMessage>>
    {
        {"UI_UPDATE", () => new UiTransactionUpdate()}
    };
    var factoryFunc = messageTypeToTypeMap[message.MessageType];
    message.Payload = RemoveNullGroupIdReference(jsonPayload, message.Payload);
    var ruleMessage = factoryFunc.Invoke();
    var deserializedMessage = ruleMessage.DeserializeToBaseBaseRuleMessage(message);
    deserializedMessage.RulesCompleted = deserializedMessage.RulesCompleted ?? new List<int>();
    foreach (var rule in deserializedMessage.FilterRules(ruleGroup))
    {
        var isTrue = deserializedMessage.ExecuteRule(rule, deserializedMessage);
    }
