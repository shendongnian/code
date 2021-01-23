    void SomeMethod()
    {
        List parts = new List();
        // Add parts to the list.
        parts.Add(new Part() { PartName = "crank arm", PartId = 1234});
        parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
        parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
        parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
        parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
        parts.Add(new Part() { PartName = "shift lever", PartId = 1634 });
    }
    public class Part
    {
        public string PartName { get; set; }
        public string PartId { get; set; }
    }
