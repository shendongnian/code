    int quantityNumber;
    if (string.IsNullOrWhiteSpace(QuantityBox.Text) 
        || !int.TryParse(QuantityBox.Text, out quantityNumber)) {
        throw new ArgumentException(
            $"Expected an integer in QuantityBox, but actual value was '{QuantityBox.Text}'.", 
            nameof(QuantityBox.Text)
        );
    }
    // if we reach this line, quanityNumber has a valid value assigned
