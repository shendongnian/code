        public async Task<IActionResult> PostJoke([FromBody] Joke joke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var author = _context.Find<User>(joke.Author.UserId);
            if (author != null)
            {
                //existing author
                joke.Author = author;
            }
            _context.Jokes.Add(joke);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetJoke", new { id = joke.JokeId }, joke);
        }
