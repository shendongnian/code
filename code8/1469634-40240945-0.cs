        private void DrawLine(int serviceTime, string lineName)
        {
            while (serviceTime != 0)
            {
                DispatcherService.BeginInvoke(() =>
                {
                        (this[lineName] as ObservableCollection<Line>).Add(new Line { X1 = x1, Y1 = y1, X2 = x2, Y2 = y2 });
                });
                x1 += 10;
                x2 += 10;
                serviceTime--;
                Thread.Sleep(500);
            }
            ResetXY();
        }
