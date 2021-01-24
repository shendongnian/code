    public class DefaultController : Controller
        {
            protected StackOverflowAnswersContext db = new StackOverflowAnswersContext();
            
            public ActionResult Details(int? id)
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    
                Person person = db.Persons.Find(id);
                if (person == null)
                    return HttpNotFound();
    
                PersonWIthRoomCountViewModel model = new PersonWIthRoomCountViewModel();
    
                model.Name = person.Name;
                model.City = person.City;
                var DecoratedRooms = db.Rooms.Where(ww => ww.PersonID == id && ww.Decorated);
                if (DecoratedRooms == null)
                {
                    model.DecoratedRoomsAllocated = 0;
                }
                else
                {
                    model.DecoratedRoomsAllocated = DecoratedRooms.Count();
                }
    
                return View(model);
            }
        }
