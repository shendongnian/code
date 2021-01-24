    if (changeObject.Text == null)
    {
        var c = new ChangeType();
        JToken.FromObject(c, s).WriteTo(writer);
    }
    else
        writer.WriteValue(changeObject.Text);
