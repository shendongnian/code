    public class Card
    {
        public ImageSource Image { get; set; }
        ...
    }
    ...
    var card = new Card
    {
        Image = new BitmapeImage(new Uri("pack://application:,,,/Picures/Luigi.jpg"))
    };
