    Line line = new Line();
    line.Tag = "Some Value";
    line.MouseUp += (sender, args) =>
                      {
                         var myValue = ((Line)sender).Tag;
                         Debug.WriteLine($"My value : {myValue}");
                      };
