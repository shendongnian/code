    namespace heightmap_generator {
    internal class Program {
        private static int GRID_SIZE = 1081;
        private static void Main(string[] args) {
            using (MagickImage image = new MagickImage(@"C:\Users\Brent\AppData\Local\Colossal Order\Cities_Skylines\Addons\MapEditor\Heightmaps\benchmark.png")) {
                image.Draw(
                    new DrawableFillColor(new MagickColor(ushort.MaxValue / 2, ushort.MaxValue / 2, ushort.MaxValue / 2)),
                    new DrawableRectangle(0, 0, GRID_SIZE, GRID_SIZE)
                );
                var drawables = new List<IDrawable>();
                for (var y = 0; y < GRID_SIZE/50;  ++y) {
                    float t = y / (GRID_SIZE / 50.0f);
                    t = t*t*(3 - 2*t); //cubic hermite spline h01
                    ushort v = (ushort)(ushort.MaxValue * (5 + (t-1)*0.3) / 10);
                    if (y == GRID_SIZE/50 - 1) {
                        v = (ushort) (ushort.MaxValue*0.501);
                    }
                    drawables.Add(new DrawableFillColor(new MagickColor(v, v, v)));
                    for (var x = 0; x < GRID_SIZE; ++x) {
                        if (x == GRID_SIZE/2) {
                            var v2 = (ushort) (v + ushort.MaxValue/1024);
                            drawables.Add(new DrawableFillColor(new MagickColor(v2, v2, v2)));
                            drawables.Add(new DrawableColor(x, GRID_SIZE/2 - y, PaintMethod.Point));
                            drawables.Add(new DrawableColor(x, GRID_SIZE/2 + y, PaintMethod.Point));
                            drawables.Add(new DrawableFillColor(new MagickColor(v, v, v)));
                        } else {
                            drawables.Add(new DrawableColor(x, GRID_SIZE/2 - y, PaintMethod.Point));
                            drawables.Add(new DrawableColor(x, GRID_SIZE/2 + y, PaintMethod.Point));
                        }
                    }
                }
                image.Draw(drawables);
                image.Write(new FileStream(@"C:\Users\Brent\AppData\Local\Colossal Order\Cities_Skylines\Addons\MapEditor\Heightmaps\benchmark3.png", FileMode.Create));
            }
        }
    }
}
