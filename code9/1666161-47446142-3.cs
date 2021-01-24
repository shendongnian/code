    var times1 = new List<float>();
    for (var i = 0; i < 100; i++)
    {
        var sw = Stopwatch.StartNew();
        var mat = SharpDX.Matrix3x2.Identity;
        var s = SharpDX.Matrix3x2.Scaling(13);
        var r = SharpDX.Matrix3x2.Rotation(13);
        var t = SharpDX.Matrix3x2.Translation(13, 13);
        for (var j = 0; j < 10000; j++)
        {
            mat *= s;
            mat *= r;
            mat *= t;
        }
        sw.Stop();
        times1.Add(sw.ElapsedTicks);
    }
    var times2 = new List<float>();
    for (var i = 0; i < 100; i++)
    {
        var sw = Stopwatch.StartNew();
        var mat = System.Numerics.Matrix3x2.Identity;
        var s = System.Numerics.Matrix3x2.CreateScale(13);
        var r = System.Numerics.Matrix3x2.CreateRotation(13);
        var t = System.Numerics.Matrix3x2.CreateTranslation(13, 13);
        for (var j = 0; j < 10000; j++)
        {
            mat *= s;
            mat *= r;
            mat *= t;
        }
        sw.Stop();
        times2.Add(sw.ElapsedTicks);
    }
