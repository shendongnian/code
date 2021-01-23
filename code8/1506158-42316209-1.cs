    public class FlowCellImage : FlowViewCell
        {
            private Image ImgPost;
            public FlowCellImage()
            {
                ImgPost = new Image
                {
                    Aspect = Aspect.AspectFill
                };
                ImgPost.SetBinding(Image.SourceProperty, "ThumbnailUrl");
                HeightRequest = Application.Current.MainPage.Width / 3;
                Content = ImgPost;
            }
        } 
