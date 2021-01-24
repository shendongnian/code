       private void Grid_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Left)
            {
                Move(-1, 0);
            }
            else if (e.Key == VirtualKey.Right)
            {
                Move(1, 0);
            }
            else if (e.Key == VirtualKey.Up)
            {
                Move(0, -1);
            }
            else if (e.Key == VirtualKey.Down)
            {
                Move(0, 1);
            }
        }
        private void Move(int x, int y)
        {
            var temp = btn.RenderTransform as CompositeTransform;
            temp.TranslateX += x;
            temp.TranslateY += y;
        }
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {
                string str = b.Content as string;
                if (str == "up")
                {
                    Move(0, -1);
                }
                else if (str == "down")
                {
                    Move(0, 1);
                }
                else if (str == "left")
                {
                    Move(-1, 0);
                }
                else if (str == "right")
                {
                    Move(1, 0);
                }
            }
        }
    }
