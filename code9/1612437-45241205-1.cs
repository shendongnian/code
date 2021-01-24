    public class RegistroTarjaViewModel
    {
        [Required]
        public long HaciendaId { get; set; }
    
        [Required]
        public DateTime FechaTarja { get; set; }
    
        public List<RegistroPedidoTarjaViewModel> Pedidos { get; set; }
        public long? ContenedorId { get; set; }
    }
    
    public class RegistroPedidoTarjaViewModel
    {
        public long PedidoEmbarqueId { get; set; }
        public string Embarcadas { get; set; }
    }
