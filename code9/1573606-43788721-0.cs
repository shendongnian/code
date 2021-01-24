    private void Button_Click(object sender, RoutedEventArgs e)
        {
          flag = !flag;
    
          var list = new List <ChartPoint>();
    
          Task.Factory.StartNew(() =>
          {
            for (int i = 0; i < 50000000; i++)
            {
              if (flag == false) break;
              m.MyValue = i.ToString();
              Dispatcher.BeginInvoke(new Action(() =>
                                                {
                                                  m.MyCollection.Add(new ChartPoint
                                                                     {
                                                                       A = i,
                                                                       B = 2 * i
                                                                     });
                                                }),
                                     DispatcherPriority.Background);
            }
          });
        }
