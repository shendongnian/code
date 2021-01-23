	public partial class FotoEnvolvido : ContentPage
	{
		public ImageSource Imagem {get; set; }
		public FotoEnvolvido(ImageSource imagem)
		{
			InitializeComponent();
			Imagem = imagem;
			BindingContext = this;
		}
	}
    <Image Source="{Binding Imagem}" x:Name="fotoperfil"/>
