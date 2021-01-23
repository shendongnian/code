            private void SetPos()
            {
                var relativePosition = Mouse.GetPosition(this.MainCanvas);
                Canvas.SetLeft(this.btn1, relativePosition.X);
                Canvas.SetTop(this.btn1, relativePosition.Y);
                btn1.Visibility = Visibility.Visible;
            }
