    public class ContactSanitizer
    {
        public void Sanitize(ContactDto contact)
        {
            var phone = contact.Phone;
            if (phone.StartsWith("+"))
                contact.Phone = phone.Replace("+", "00");
        }
    }
