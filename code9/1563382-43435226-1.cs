    using(MyDBContext ctx = new MyDBContext())
    {
        ctx.UpdateChildName(1, "ABCDE");
        ctx.SubmitChanges();         //   <--- Now working great.
    };
