    public class HomeController : Controller
    {
        public ActionResult Registrar()
        {
            List<RegistroPedidoTarjaViewModel> data = new List<RegistroPedidoTarjaViewModel>();
            data.Add(new RegistroPedidoTarjaViewModel {PedidoEmbarqueId = 1, Embarcadas = "One"});
            data.Add(new RegistroPedidoTarjaViewModel {PedidoEmbarqueId = 2, Embarcadas = "Two"});
            data.Add(new RegistroPedidoTarjaViewModel {PedidoEmbarqueId = 3, Embarcadas = "Three"});
            data.Add(new RegistroPedidoTarjaViewModel {PedidoEmbarqueId = 4, Embarcadas = "Four"});
    
            return View(new RegistroTarjaViewModel
            {
                HaciendaId = 1,
                FechaTarja = DateTime.Now,
                Pedidos = data
            });
        }
    
        [HttpPost]
        public ActionResult Registrar(RegistroTarjaViewModel model)
        {
            if (ModelState.IsValid)
            {
    
            }
            return View(model);
        }
    }
