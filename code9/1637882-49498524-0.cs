    public partial class CPage_Perfil : ContentPage
        {
           //Constructors
            public CPage_Perfil()
            {
    
                InitializeComponent();
                NavigationPage.SetHasBackButton(this, true);
                Title = "PERFIL";
    
                this.ToolbarItems.Add(new ToolbarItem
                {
                    Icon = "Editarmdpi.png",
                    Name = "Editar",
    
               Command = new Command(() => DisplayAlert("Selected", "menu1", "OK"))
                });
              
    
            }
