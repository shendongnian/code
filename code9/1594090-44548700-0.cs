       @foreach (Categorie c in Model.Where(w=>w.HoofdCategorieId == 0))
            {
                 <li>@c.Naam </li>
     @foreach (Categorie subC in    Model.Where(w=>w.HoofdCategorieId == c.Id))
            {
                 <li>@SubC.Naam </li>
     @foreach (Categorie subSubC in      Model.Where(w=>w.HoofdCategorieId == SubC.Id))
            {
                 <li>@subSubC.Naam </li>
             }
             }
             }
        }
   
