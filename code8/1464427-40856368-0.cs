    A a = new a(); //parent entity
    B b = new b(); //child entity which has corresponding b.A navigation
                   //property and b.AId field for referencing 'A' entity primary
                   //key.
    // Omit this line. a.b = b;
    context.AddToAs(a);
    context.AddToBs(b);
    context.SetLink(b, "A", a);
    context.BeginSaveChanges(o=>{
        //some after-save code here
    }, null);
