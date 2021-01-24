    using System.Linq;
    ... 
    soanthao form = Application
      .OpenForms
      .OfType<soanthao>()
      .LastOrDefault(); // If many soanthao are opened, take the last one
    if (soanthao != null) {
      // form is the soanthao instance opened
    }
    else {
      // no opened soanthao instance
    }
