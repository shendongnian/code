        public ActionResult Test()
        {
            dynamic contact = new ExpandoObject();
            // this part is static for now, will be get input settings from database
            contact.Name = new CustomModelEditor();
            contact.Name.Value = null;
            contact.Name.Name = nameof(contact.Name);
            contact.Name.DefaultValue = "Not Set";
            contact.Name.IsRequired = true;
            contact.Email = new CustomModelEditor();
            contact.Email.Name = nameof(contact.Email);
            contact.Email.Value = "";
            contact.Email.InputType = DataModels.InputType.Email;
            contact.Email.DefaultValue = "";
            contact.Email.IsRequired = true;
            return View(contact);
        }
