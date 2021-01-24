    var mean = Enumerable.Range(0, image.Height)
                         .AsParallel()
                         .Select(i => Enumerable.Range(0, image.Width)
                                                .AsParallel()
                                                .Sum(j => (double)image[i, j] / totalPixels))
                         .Sum();
