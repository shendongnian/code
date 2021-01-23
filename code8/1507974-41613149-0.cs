     var toUpdate= ctx.ContactPhones.Find(YourIdToUpdate);
     toUpdate.Number = newPhone;
     var toDelete= new ContactPhone{ Id = 1 };
     ctx.ContactPhones.Attach(toDelete);
     ctx.ContactPhones.Remove(toDelete);
     ctx.SaveChanges();
