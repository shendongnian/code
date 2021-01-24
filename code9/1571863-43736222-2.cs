	private bool CheckEntry(string name) {
		foreach (Contact contact in contacts) {
			if (contact == null) { // First if
				continue;
			} else {
				if (contact != null && contact.Name != name) { // Second if
					continue;
				} else {
					if (contact.Name == name) { // Third if
						return false;
					}
				}
			}
		}
		return true;
	}
