            while (true)
            {
                if (dotIndicatorTokenSource.IsCancellationRequested)
                {
                    break;
                }
                Dispatcher.Invoke(() =>
                {
                    connectionIndicatorDotImg.Visibility = Visibility.Hidden;
                });
                Thread.Sleep(halfPeriod);
                if (dotIndicatorTokenSource.IsCancellationRequested)
                {
                    break;
                }
                Dispatcher.Invoke(() =>
                {
                    connectionIndicatorDotImg.Visibility = Visibility.Visible;
                });
                Thread.Sleep(halfPeriod);
                if (dotIndicatorTokenSource.IsCancellationRequested)
                {
                    break;
                }
            }
