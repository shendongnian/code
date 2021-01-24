    /// <summary>Creates Image XObject from image and adds it to the specified position with specified width preserving aspect ratio.
    ///     </summary>
    /// <param name="asInline">true if to add image as in-line.</param>
    /// <returns>created XObject or null in case of in-line image (asInline = true).</returns>
    public virtual PdfXObject AddImage(ImageData image, float x, float y, float width, bool asInline)
    /// <summary>Creates Image XObject from image and adds it to canvas.</summary>
    /// <param name="asInline">true if to add image as in-line.</param>
    /// <returns>created XObject or null in case of in-line image (asInline = true).</returns>
    public virtual PdfXObject AddImage(ImageData image, iText.Kernel.Geom.Rectangle rect, bool asInline)
    /// <summary>Creates Image XObject from image and adds it to canvas.</summary>
    /// <param name="image">
    /// the
    /// <c>PdfImageXObject</c>
    /// object
    /// </param>
    /// <param name="a">an element of the transformation matrix</param>
    /// <param name="b">an element of the transformation matrix</param>
    /// <param name="c">an element of the transformation matrix</param>
    /// <param name="d">an element of the transformation matrix</param>
    /// <param name="e">an element of the transformation matrix</param>
    /// <param name="f">an element of the transformation matrix</param>
    /// <param name="asInline">true if to add image as in-line.</param>
    /// <returns>created Image XObject or null in case of in-line image (asInline = true).</returns>
    public virtual PdfXObject AddImage(ImageData image, float a, float b, float c, float d, float e, float f, 
        bool asInline)
