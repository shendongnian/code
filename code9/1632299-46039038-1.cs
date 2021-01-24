    using System.Linq;
    ... 
    soanthao st = Application
      .OpenForms
      .OfType<soanthao>()
      .LastOrDefault(); // If many soanthao are opened, take the last one
    if (st != null) {
      // form is the soanthao instance opened
    }
    else {
      // no opened soanthao instance
    }
