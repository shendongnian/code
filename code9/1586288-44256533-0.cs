    private static GetCachedReference(int id)
       => Server.Instance.Data.Items[id];
    public Item(int id) : (id, GetCachedReference(id).Value) {}
    protected Item(int id, int value)
    {
        this.ID = id;
        this.Value = value;
    }
---
    private static GetCachedReference(int id)
       => Server.Instance.Data.Equips[this.ID];
    public Item CachedReference => GetCachedReference(ID);
    public new Equip CachedReference => GetCachedReference(ID);
    public Equip(int id) : base(id, GetCachedReference(id).Value) { }
