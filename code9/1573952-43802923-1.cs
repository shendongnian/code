    public class PeticioneController : Controller
    {
            public ActionResult Detail(int peticonID)
            {
                var peticoneService = new PeticoneService();
    
                var peticoneViewModel = new PeticoneViewModel();
                peticoneViewModel.CurrentPeticione = peticoneService.GetPeticioneByID(peticonID);
    
                return View("Detail",peticoneViewModel);
            }
    
           public bool UpdatePeticone(int id, string newValue)
           {
                if (id > 0)
                {
                    var peticoneService = new PeticoneService();
                    return peticoneService.SavePeticioneByID(id, newValue);
                }
        
                return false;
            }
     }
