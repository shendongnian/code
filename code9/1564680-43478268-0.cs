    var obj = JObject.FromObject(new
    {
        attachment = new
        {
            type = "template",
            payload = new
            {
                template_type = "button",
                text = Title,
                buttons = new JObject(
                    new JProperty("type", Type),
                    new JProperty(Variable1, Value),
                    new JProperty(Variable2, Payload))
            }
        }
    });
