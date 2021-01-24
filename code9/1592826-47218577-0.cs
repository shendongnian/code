    #if DEBUG
        [ApiExplorerSettings(IgnoreApi = true)]
    #else
        [ApiExplorerSettings(IgnoreApi = false)]
    #endif
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(BdlgDataStorage))]
        [HttpGet, Route("api/bdlg")]
        private async Task<BdlgDataStorage> GetBdlgStorageValues()
        {
            using (var context = new BdlgContext())
                return context.BdlgDataStorages
                    .Include(s=>s.ChangeTrack)
                    .Where(w=>w.Isle > 56)
                    .Select(selectorFunction)
                    .ToListAsync();
        }
