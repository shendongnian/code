    public class MoviesController : ApiController
    {
        // POST /api/movies/
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
    
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
    
            return Created(new Uri($"{Request.RequestUri}/{movie.Id}"), movie);
            }
    
        // PUT /api/movies/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
    
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
    
            if (movieInDb == null)
                return NotFound();
    
            Mapper.Map(movieDto, movieInDb);
    
            _context.SaveChanges();
    
            return Ok();
    
        }
    
        // DELETE /api/movies/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
    
            if (movieInDb == null)
                    return NotFound();
    
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
    
            return Ok();
        }
    }
