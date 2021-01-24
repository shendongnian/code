    /// <summary>
    ///  Takes a string, text format, and associated constraints, and produces an object that represents the fully analyzed and formatted result.
    /// </summary>
    /// <param name="factory">an instance of <see cref="T:SharpDX.DirectWrite.Factory" /></param>
    /// <param name="text">An array of characters that contains the string to create a new <see cref="T:SharpDX.DirectWrite.TextLayout" /> object from. This array must be of length stringLength and can contain embedded NULL characters.</param>
    /// <param name="textFormat">A pointer to an object that indicates the format to apply to the string.</param>
    /// <param name="maxWidth">The width of the layout box.</param>
    /// <param name="maxHeight">The height of the layout box.</param>
    /// <unmanaged>HRESULT CreateTextLayout([In, Buffer] const wchar* string,[None] UINT32 stringLength,[None] IDWriteTextFormat* textFormat,[None] FLOAT maxWidth,[None] FLOAT maxHeight,[Out] IDWriteTextLayout** textLayout)</unmanaged>
    public TextLayout(Factory factory, string text, TextFormat textFormat, float maxWidth, float maxHeight)
