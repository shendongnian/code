    public class MyAdapter : RecyclerView.Adapter
    {
        private JavaList<News> news;
        private Context context;
        public MyAdapter(JavaList<News> news, Context context)
        {
            this.news = news;
            this.context = context;
        }
       ......
     //Then in your OnBindViewHolder you can call getResources
      .....
       hold.Img.SetImageBitmap(BitmapImages.decodeSampledBitmapFromResource(context.getResources(),news[position].Image,100,100));
     }
