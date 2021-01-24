    /// <param name="entity"></param>
	public override void Update(Group entity) {
		// entity as it currently exists in the db
		var group = DbContext.Groups.Include(c => c.Contacts)
			.FirstOrDefault(g => g.Id == entity.Id);
		// update properties on the parent
		DbContext.Entry(group).CurrentValues.SetValues(entity);
		// remove or update child collection items
		var groupContacts = group.Contacts.ToList();
		foreach (var groupContact in groupContacts) {
			var contact = entity.Contacts.SingleOrDefault(i => i.ContactId == groupContact.ContactId);
			if (contact != null)
				DbContext.Entry(groupContact).CurrentValues.SetValues(contact);
			else
				DbContext.Remove(groupContact);
		}
		// add the new items
		foreach (var contact in entity.Contacts) {
			if (groupContacts.All(i => i.Id != contact.Id)) {
				group.Contacts.Add(contact);
			}
		}
		DbContext.SaveChanges();
	}
