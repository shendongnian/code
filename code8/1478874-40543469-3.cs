    /// <summary>Specifies an array of <see cref="T:System.Drawing.CharacterRange" /> structures that represent the ranges of characters measured by a call to the <see cref="M:System.Drawing.Graphics.MeasureCharacterRanges(System.String,System.Drawing.Font,System.Drawing.RectangleF,System.Drawing.StringFormat)" /> method.</summary>
    /// <param name="ranges">An array of <see cref="T:System.Drawing.CharacterRange" /> structures that specifies the ranges of characters measured by a call to the <see cref="M:System.Drawing.Graphics.MeasureCharacterRanges(System.String,System.Drawing.Font,System.Drawing.RectangleF,System.Drawing.StringFormat)" /> method.</param>
    /// <exception cref="T:System.OverflowException">More than 32 character ranges are set.</exception>
    public void SetMeasurableCharacterRanges( CharacterRange[] ranges )
    {
        int num = SafeNativeMethods.Gdip.GdipSetStringFormatMeasurableCharacterRanges( new HandleRef( this, this.nativeFormat ), ranges.Length, ranges );
        if( num != 0 )
            throw SafeNativeMethods.Gdip.StatusException( num );
    }
