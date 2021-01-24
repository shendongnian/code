    private OnValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args) {
        string message = Encoding.ASCII.GetString(args.CharacteristicValue.ToArray());
        // Parse `message`
        var parsed = parsingServce.Parse(message);
        SomeProperty = parsed;
    }
