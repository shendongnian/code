    public class Sapo
    {
        public int IdSapo { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }
        public BitmapImage Image { get; private set; }
        public Sapo(int id)
        {
            IdSapo = id;
            Width = 56;
            Height = 56;
            Image = new BitmapImage(new Uri("pack://application:,,,/Imagens/sapo.png"));
            Image.Freeze();
        }
    }
