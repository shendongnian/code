    public class KreatorZamowien
    {
        public int Id { get; set; }
        public int NumerZamowienia { get; set; }
        public virtual ICollection<Nabywca> Nabywcy { get; set; } = new Hashset<Nabywca>();
    }
    
    public class Nabywca
    {
        public int NabywcaId { get; set; }
        public string Nazwa { get; set; }
        public virtual ICollection<KreatorZamowien> KreatoryZamowien { get; set; } = new Hashset<KreatorZamowien>();
    }
    
    public ActionResult Create(KreatorZamowienNabywca model)
    {
        model.KreatorZamowien.Nabywcy.Add(model.Nabywca);
        model.Nabywca.KreatoryZamowien.Add(model.KreatorZamowien);
    
        db.KreatoryZamowien.Add(model.KreatorZamowien);
        db.Nabywcy.Add(model.Nabywca);
        db.SaveChanges();
    }
