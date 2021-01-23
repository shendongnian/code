     [HttpDelete("{Id}")]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            Item itemToRemove = Repo.Find(Id);
            if (itemToRemove == null)
            {
                return BadRequest();
            }
            Repo.Delete(itemToRemove );
            return NoContent();
        }
