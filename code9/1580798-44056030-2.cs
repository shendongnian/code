    [RoutePrefix("api/favoritearticles"]
    public class FavoriteArticlesController : BaseController<FavoriteArticle, Guid> {
        
        [HttpPost]
        [Route("{articleId:guid}")] //Matches POST api/favoritearticles/{articleId:guid}
        public IHttpActionResult SetFavorite(Guid articleId) {            
            var favorite = new FavoriteArticle
            {
                UserId = UserInfo.GetUserId(),
                ArticleId = articleId
            };
            _repo.Upsert(favorite);
            _repo.Commit();
            return Ok(new { Success = true, Error = (string)null });
        }
        [HttpDelete]
        [Route("{articleId:guid}")] //Matches DELETE api/favoritearticles/{articleId:guid}
        public IHttpActionResult RemoveFavorite(Guid articleId) {            
            var favorite = _repo.GetAll()
                .First(fa => fa.ArticleId == articleId);
            if(favorite == null) return NotFound();
            _repo.Delete(favorite.Id);
            _repo.Commit();
            return Ok(new { Success = true, Error = (string)null });
        }
    }
