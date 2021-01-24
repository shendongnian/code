    using Nito.AsyncEx;
        // ...
        private static readonly AsyncLock _assetsMutext = new AsyncLock();
        public List<Expression<Func<sset, bool>>> Filters { get; } = new List<Expression<Func<Asset, bool>>>();
        // ...
        public async Task<IQueryable<Asset>> LoadAssetsOnTrack(IList<Asset> trackAssets, List<Asset> assets)
        {
            IQueryable<IAsset> query = null;
            await Task.Run(async () =>
            {
                using (await _assetsMutext.LockAsync())
                {
                    var equipmentList = this.GetEquipment();
                    Parallel.ForEach(trackAssets, (asset, state) =>
                    {
                        if (!AssetRepository.GetIsAssetTrackType(asset.TypeCode))
                        {
                            var equipment = equipmentList.Where(x => x.AssetID == asset.AssetID).FirstOrDefault();
                            var inspectionAsset = new Asset()
                            {
                                AssetID = equipment?.AssetID,
                                Description = equipment?.Description,
                                // ...
                            };
                            // ...
                            assets.Add(inspectionAsset);
                        }
                    });
                    query = assets.AsQueryable();
                    foreach (var filter in Filters)
                    {
                        query = query.Where(filter);
                    }
                }
            });
            return query;
        }
