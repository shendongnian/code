	class Contact {
		public string Name { get; private set; }		// use a property with a private setter, instead of a public member
		public string Address { get; private set; }     // use a property with a private setter, instead of a public member
		public Contact(string name, string address) {
			Name = name;
			Address = address;
		}
	}
	//------------------------------------------------------------------------
	class AddressBook {
		public readonly Contact[] contacts;
		public AddressBook() {
			contacts = new Contact[2]; // I am assuming you kept the size 2 for testing
		}
		public bool AddEntry(string name, string address) {
			if (!ContainsEntry(name)) {
				Contact AddContact = new Contact(name, address);
				for (int i = 0; i < contacts.Length; i++) {
					if (contacts[i] == null) {
						contacts[i] = AddContact;
						Console.WriteLine("Address Book updated. {0} has been added!", name);
						return true;
					}
				}
				Console.WriteLine($"Cannot add name ({name}) to Address Book since it is full!");
				// TODO: Throw some exception or specific return values to indicate the same to the caller
			} else {
				Console.WriteLine($"Name ({name}) already exists in Address Book!");
				// TODO: Update the address?
			}
			return false;
		}
		private int GetEntryIndex(string name) {
			for (int i = 0; i < contacts.Length; i++) {
				if (contacts[i] != null && contacts[i].Name == name)
					return i;
			}
			return -1;
		}
		private bool ContainsEntry(string name) {
			return GetEntryIndex(name) != -1;
		}
		public void RemoveEntry(string name) {
			var index = GetEntryIndex(name);
			if (index != -1) {
				contacts[index] = null;
				Console.WriteLine("{0} removed from contacts", name);
			}
		}
		public string View() {
			string contactList = "";
			foreach (Contact contact in contacts) {
				if (contact == null) {
					continue;	// Don't break, but simply continue to look further
				}
				contactList += String.Format("Name: {0} -- Address: {1}" + Environment.NewLine, contact.Name, contact.Address);
			}
			return contactList;
		}
	}
