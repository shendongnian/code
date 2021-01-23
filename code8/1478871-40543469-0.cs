    // System.Drawing.StringFormat
    /// <summary>Gibt ein Array von <see cref="T:System.Drawing.CharacterRange" />-Strukturen an, die die durch einen Aufruf der <see cref="M:System.Drawing.Graphics.MeasureCharacterRanges(System.String,System.Drawing.Font,System.Drawing.RectangleF,System.Drawing.StringFormat)" />-Methode gemessenen Zeichenbereiche darstellt.</summary>
    /// <param name="ranges">Ein Array von <see cref="T:System.Drawing.CharacterRange" />-Strukturen, das die durch einen Aufruf der <see cref="M:System.Drawing.Graphics.MeasureCharacterRanges(System.String,System.Drawing.Font,System.Drawing.RectangleF,System.Drawing.StringFormat)" />-Methode gemessenen Zeichenbereiche angibt. </param>
    /// <exception cref="T:System.OverflowException">Es sind mehr als 32 Zeichenbereiche festgelegt.</exception>
    /// <filterpriority>1</filterpriority>
    public void SetMeasurableCharacterRanges( CharacterRange[] ranges )
    {
        int num = SafeNativeMethods.Gdip.GdipSetStringFormatMeasurableCharacterRanges( new HandleRef( this, this.nativeFormat ), ranges.Length, ranges );
        if( num != 0 )
            throw SafeNativeMethods.Gdip.StatusException( num );
    }
