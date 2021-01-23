    /// <summary>
    /// Linearly interpolates from one vector to another based on the given weighting. 
    /// The two vectors are premultiplied before operating.
    /// </summary>
    /// <param name="backdrop">The backdrop vector.</param>
    /// <param name="source">The source vector.</param>
    /// <param name="amount">
    /// A value between 0 and 1 indicating the weight of the second source vector.
    /// At amount = 0, "from" is returned, at amount = 1, "to" is returned.
    /// </param>
    /// <returns> 
    /// The <see cref="Vector4"/>
    /// </returns>
    public static Vector4 PremultipliedLerp(Vector4 backdrop, Vector4 source, float amount)
    {
        amount = amount.Clamp(0, 1);
        // Santize on zero alpha
        if (Math.Abs(backdrop.W) < Epsilon)
        {
            source.W *= amount;
            return source;
        }
        if (Math.Abs(source.W) < Epsilon)
        {
            return backdrop;
        }
        // Premultiply the source vector.
        // Oddly premultiplying the background vector creates dark outlines when pixels
        // Have low alpha values. 
        source = new Vector4(source.X, source.Y, source.Z, 1) * (source.W * amount);
        // This should be implementing the following formula
        // https://en.wikipedia.org/wiki/Alpha_compositing
        // Vout =  Vs + Vb (1 - Vsa)
        // Aout = Vsa + Vsb (1 - Vsa)
        Vector3 inverseW = new Vector3(1 - source.W);
        Vector3 xyzB = new Vector3(backdrop.X, backdrop.Y, backdrop.Z);
        Vector3 xyzS = new Vector3(source.X, source.Y, source.Z);
        return new Vector4(xyzS + (xyzB * inverseW), source.W + (backdrop.W * (1 - source.W)));
    }
