    public Image CodeImage {
        get {
            int minWidth = Math.Max(100, barcode.EncodedValue.Length);
            return barcode.Encode(barcode.EncodedType, code, minWidth, 35);
        }
    }
