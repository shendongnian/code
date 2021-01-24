                Excel.Shape shape;
                shape = shapes.AddChart2(-1, Excel.XlChartType.xlColumnClustered);
                Console.WriteLine(" --- 1st chart filling --- ");
                CreateSeries(shape);
                shape = shapes.AddChart2(-1, Excel.XlChartType.xlColumnClustered);
                Console.WriteLine(" --- 2nde chart filling --- ");
                CreateSeries(shape);
