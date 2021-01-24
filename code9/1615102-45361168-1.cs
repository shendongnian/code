        private void TestSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Storyboard sb = Main.FindResource("Weeeee") as Storyboard;
            sb.Stop(object_to_move);
            var ratio = sb.Duration.TimeSpan.TotalMilliseconds/2 * TestSlider.Value;
            sb.Seek(object_to_move, new TimeSpan(0,0,0,0,(int)ratio), TimeSeekOrigin.BeginTime);
            sb.Pause(object_to_move);            
        }
        private void Main_OnLoaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = Main.FindResource("Weeeee") as Storyboard;
            sb.Begin(object_to_move, true);
            sb.Stop(object_to_move);
        }
