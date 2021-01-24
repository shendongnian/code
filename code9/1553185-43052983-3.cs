    @model List<Students>
    
    @Model[0].FirstName // Displays the Firstname of the student in position 0 in the list 
    
    // This foreach loop displays all the students Firstname
    @foreach (var item in Model)
    {
        @item.FirstName
    }
    
    // Same as above but with for loop
    @for (int i = 0; i < Model.Count; i++)
    {
        <p> @Model[i].FirstName </p>
    }
