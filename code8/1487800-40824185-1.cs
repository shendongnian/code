            SelectPointCommand = new RelayCommand(
                    (x) =>
                    {
                        Console.WriteLine("This is executed every click");
                        ClickCounter++;
                        if (ClickCounter == 3)
                        {
                            ClickCounter = 0;
                            CanEdit = false;
                        }
                        Polygons.Add(new Polygon(ClickedPoints));
                        ClickedPoints.Clear();
                    },
                    (x) => { return CanEdit; });
