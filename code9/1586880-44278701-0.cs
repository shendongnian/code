    using System.Linq;
    ...
    // Do we have any Form2 intances opened?
    Form2 frm2 = Application
      .OpenForms
      .OfType<Form2>()
      .LastOrDefault(); // <- If we have many Form2 instances, let's take the last one 
    // ...No. We have to create and show Form2 instance
    if (null == frm2) {
      frm2 = new Form2();
      frm2.Show(); 
    }
    else { // ...Yes. We have to activate it (i.e. bring to front, restore if minimized, focus)
      frm2.Activate();
    }
