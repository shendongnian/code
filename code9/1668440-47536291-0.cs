    public IActionResult GetAllContacts()
    {
         List<Contacts> contacts = contactService.RetrieveAllContacts();
         return Json(contacts);
    }
