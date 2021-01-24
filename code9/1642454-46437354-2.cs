    async Task RotateImageContinously()
    {
        while (true) // a CancellationToken in real life ;-)
        {
            for (int i = 1; i < 7; i++)
            {
                if (image.Rotation >= 360f) image.Rotation = 0;
                await image.RotateTo(i * (360 / 6), 1000, Easing.CubicInOut);
            }
        }
    }
