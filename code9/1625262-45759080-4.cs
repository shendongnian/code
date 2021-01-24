    // this is crucial as it gives the the measurement and drawing capabilities
    // to the item itself instead of a parent ( ComboBox )
    taskSelectionComboBox.DrawMode = DrawMode.OwnerDrawVariable;
    taskSelectionComboBox.DrawItem +=TaskSelectionDrawItem;
    taskSelectionComboBox.MeasureItem += TaskSelectionMeasureItem;
