    @functions {
    
        public static string ApiCall()
        {
            return "Hello World!";
        }
    }
    @{
        var ratings = ApiCall();
    }
    
    @if (ratings != null)
    {
        <div class="gig-rating-stars" content=@ratings></div>
    }
