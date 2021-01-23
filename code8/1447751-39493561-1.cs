	public partial class FotoEnvolvido : ContentPage
	{
		public FotoEnvolvido(ImageSource imagem)
		{
			InitializeComponent();
			BindingContext = imagem;
		}
	}
    <Image Source="{Binding}" x:Name="fotoperfil"/>
