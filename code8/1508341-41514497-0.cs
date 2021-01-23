    [Route("{id}")]
    public async Task<IHttpActionResult> DeleteStudySubset(int id)
    {
        await _subsetRepo.DeleteStudySubset(id);
        return Ok();
    }
