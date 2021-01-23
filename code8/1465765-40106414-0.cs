    void Main()
    {
        B test = new B();
        [some instruction]
        trans = conn.BeginTrans();
        test.Save(trans);
    }
---
     Class B
     {
        void Save(IDBTransaction transaction)
        {
      
        }
    }
