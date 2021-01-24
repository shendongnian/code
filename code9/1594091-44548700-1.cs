    @foreach (Categorie c in Model.Where(w => w.HoofdCategorieId == 0))
    {
        <li>@c.Naam </li>
        foreach (Categorie subC in Model.Where(w => w.HoofdCategorieId == c.Id))
        {
            <li style="margin-left:5px;">@subC.Naam </li>
            foreach (Categorie subSubC in Model.Where(w => w.HoofdCategorieId == subC.Id))
            {
                <li style="margin-left:10px;">@subSubC.Naam </li>
            }
        }
    }
