     private void setuptabseparator()
                {
                    float itemWidth = (float)Math.Floor(this.TabBar.Frame.Size.Width / this.TabBar.Items.Length);
                    UIView bgView = new UIView(new CGRect(5, 0, this.TabBar.Frame.Size.Width, this.TabBar.Frame.Size.Height - 5));
                    for (int i = 0; i < this.TabBar.Items.Length - 1; i++)
                    {
                        float SEPARATOR_WIDTH = 0.8f;
                        UIView separator = new UIView(new CGRect((itemWidth * (i + 1) - SEPARATOR_WIDTH), 0, SEPARATOR_WIDTH, this.TabBar.Frame.Size.Height));
                        separator.BackgroundColor = UIColor.White;
                        bgView.AddSubview(separator);
                    }
                    UIGraphics.BeginImageContext(bgView.Bounds.Size);
                    CGContext context = UIGraphics.GetCurrentContext();
                    bgView.Layer.RenderInContext(context);
                    UIImage tabbarbackground = UIGraphics.GetImageFromCurrentImageContext();
                    this.TabBar.BackgroundImage = tabbarbackground;
        
               }
