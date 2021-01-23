    public class DominioParaViewModelProfile : Profile
    {
        public DominioParaViewModelProfile()
        {
            CreateMap<Usuario, UsuarioIndexViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
