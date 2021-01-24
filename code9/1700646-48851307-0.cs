        class Program
        {
            static void Main(string[] args)
            {
                DB db = new DB();
                int id = 123;
                var model = (from personel in db.Personels
                             where personel.ID == id
                             from contact in db.ContactTypes
                             join contactType in db.ContactTypes on contact.ID equals contactType.ID
                             select new PersonelWithContactListDto
                             {
                                 PersonelName = personel.PersonelName,
                                 PersonelLastname = personel.PersonelSurname,
                                 PersonelPrivateNo = personel.PersonelPrivateNo,
                                 // here how to select my sublist. If I leverage
                                 // let = dbobjects.DefaultIfEmpty() then I am no 
                                 // longer able to specify contactType from another table.                             
                                 Contacts = personel.Contacts.Select(x => new Contact() {
                                     Value = x.Value,
                                     ID = x.ID
                                 }).ToList()
                             }).ToList();
            }
        }
        public class DB
        {
            public List<Personel> Personels { get; set; }
            public List<ContactType> ContactTypes { get; set; }
        }
        public class PersonelWithContactListDto
        {
            public string PersonelName { get; set; }
            public string PersonelLastname { get; set; }
            public int PersonelPrivateNo { get; set; }
            public List<Contact> Contacts { get; set; }
        }
        public class Personel
        {
            public int ID { get; set; }
            //[Required]
            public string PersonelName { get; set; }
            //[Required]
            public string PersonelSurname { get; set; }
            //[Required]
            //[Index(IsUnique = true)]
            public int PersonelPrivateNo { get; set; }
            public virtual ICollection<Contact> Contacts { get; set; }
        }
        public class Contact
        {
            public int ID { get; set; }
            public int ContactTypeId { get; set; }
            //[ForeignKey("ContactTypeId")]
            public ContactType ContactType { get; set; }
            //[Required]
            public string Value { get; set; }
            //[ForeignKey("PersonelId")]
            public virtual Personel Personel { get; set; }
            public int PersonelId { get; set; }
        }
        public class ContactType
        {
            public int ID { get; set; }
            //[Required]
            public string Value { get; set; }
        }
