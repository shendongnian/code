    @if (Request.IsAuthenticated && User.IsInRole("Admin"))
    {
      <span>S1234567G</span>
    }
    else
    {
      <span>*******</span>
    }
