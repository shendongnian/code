    public List<Review> RestReviews(Guid rIdThatYouWantoMatch)
    {
        var reviewsOfOneRestaurant= this.Reviews.Where(r=> r.RestaurantId == rIdThatYouWantoMatch).ToList();
        if( reviewsOfOneRestaurant.Count() < 3)
        {
            return null;
        }
        else 
        {
            foreach (var review in reviewsOfOneRestaurant)
            {
                var user= this.Users.Where(u=> u.Id == review.UserId).SingleOrDefault();
                if( this.Reviews.Where(r=> r.UserId == user.Id).Count() < 2)
                   reviewsOfOneRestaurant.Remove(review);
            }
            return reviewsOfOneRestaurant;
        }
    }
    public List<Match> MatchReview(List<Review> one,List<Review> two)
    {
        List<Match> list=new List<Match>();
         foreach (var review in one)
         {
            var review2= two.Where(r=>r.UserId == review.UserId).SingleOrDefault();
            if( review2 != null)
            {
                Match match = new Match();
                match.rev1=review;
                match.rev2=review2;
            }
         }
         return list;
    }
