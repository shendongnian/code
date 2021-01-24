    public class Controler
    {
    //param id is a id from company
    //to do a relationship
    public Action ControlerDetailsContact(int? id)
    {
        ViewModelContactCompany x = new ViewModelContactCompany();
        //Do a linq, sqlquery,etc
        x.Name = "sample"; //get name of company by id;
        for (;;)
        {
            //where id = contact.CompanyID
            //add a new object typeof contact to the viewmodel
            //with the data get from the relationship
            x.contacts.Add(new Contact());
        }
        //and in the final return object viewmodel  to the view 
        return View(x);
     }
