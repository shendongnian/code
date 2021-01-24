    public class Messages : Controller 
    {
         public ActionResult MessagesGridView()
         {
             // grid view populating data code lines here
             return PartialView("_GridView", data);
         }
         public ActionResult Load(int id)
         {
             // code lines to find ID here
             return PartialView("_ModalPopup", model);
         }
    }
