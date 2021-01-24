	using Dijkstra.NET.Contract;
    using Dijkstra.NET.Model;
    using Dijkstra.NET.ShortestPath;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    namespace Test.Polygon
    {
		class Program
		{
			static void Main(string[] args)
			{
				var points = new List<Point> { new Point(210, 540), new Point(330, 420), new Point(360, 420), new Point(420, 390), new Point(450, 330), new Point(480, 315), new Point(510, 270), new Point(570, 240), new Point(630, 240), new Point(690, 180), new Point(750, 150), new Point(810, 120), new Point(864, 120), new Point(864, 60), new Point(810, 60), new Point(750, 90), new Point(690, 120), new Point(630, 150), new Point(570, 150), new Point(510, 210), new Point(480, 255), new Point(450, 270), new Point(420, 330), new Point(360, 360), new Point(330, 360), new Point(156, 480) };
				var start = new Point(190, 500);
				var target = new Point(840, 80);
				var image = new Bitmap(1000, 600);
				using (var graphics = Graphics.FromImage(image))
				{
					graphics.Clear(Color.White);
					graphics.FillPie(Brushes.Blue, 190, 500, 10, 10, 0, 360);
					graphics.FillPie(Brushes.Red, 840, 80, 10, 10, 0, 360);
					graphics.DrawPolygon(new Pen(Color.Black, 2), points.ToArray());
				}
				var path = new GraphicsPath(FillMode.Winding);
				path.AddPolygon(points.ToArray());
				var pointsForConnect = DrawRaster(5, image, path);
				var dictionary = new Dictionary<uint, Point>();
				dictionary.Add(0, start);
				dictionary.Add(1, target);
				var graph = new Graph<int, string>();
				var i = 2;
				foreach (var point in pointsForConnect)
				{
					dictionary.Add((uint)i, point);
					graph.AddNode(i);
					i++;
				}
				foreach (var point in dictionary)
				{
					foreach (var point2 in dictionary)
					{
						if (point.Equals(point2))
						{
							continue;
						}
						double dist = Math.Sqrt(Math.Pow(point2.Value.X - point.Value.X, 2) + Math.Pow(point2.Value.Y - point.Value.Y, 2));
						if (dist > 50)
						{
							continue;
						}
						graph.Connect(point.Key, point2.Key, (int)dist, null);
						//graph.Connect()
					}
				}
				var dijkstra = new Dijkstra<int, string>(graph);
				IShortestPathResult result = dijkstra.Process(0, 1); //result contains the shortest path
				var shortestRouteIds = result.GetPath();
				var shortestRoutePoints = new List<Point>();
				foreach(var x in shortestRouteIds)
				{
					shortestRoutePoints.Add(dictionary[x]);
				}
				DrawDriver(shortestRoutePoints, image);
				image.Save("example.bmp");
			}
			private static void DrawDriver(List<Point> points, Bitmap image)
			{
				var pen = new Pen(Color.LightGreen, 5);
				for (var i = 0; i < points.Count - 1; i++)
				{
					var x = points[i].X;
					var y = points[i].Y;
					var x1 = points[i + 1].X;
					var y1 = points[i + 1].Y;
					DrawLineInt(image, new Point(x, y), new Point(x1, y1), pen);
				}
			}
			private static void DrawLineInt(Bitmap bmp, Point p1, Point p2, Pen pen)
			{
				using (var graphics = Graphics.FromImage(bmp))
				{
					graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
				}
			}
			private static List<Point> DrawRaster(int edge, Bitmap image, GraphicsPath path)
			{
				var points = new List<Point>();
				var countHorizontal = image.Width / edge;
				var countVertical = image.Height / edge;
				using (var graphics = Graphics.FromImage(image))
				{
					for (int x = 0; x < countHorizontal; x++)
					{
						for (int y = 0; y < countVertical; y++)
						{
							var boxX = (x * edge) + (edge / 2);
							var boxY = (y * edge) + (edge / 2);
							if (!path.IsVisible(boxX, boxY))
							{
								continue;
							}
							points.Add(new Point(boxX, boxY));
							graphics.DrawRectangle(Pens.LightGray, x * edge, y * edge, edge, edge);
						}
					}
				}
				return points;
			}
		}
    }
