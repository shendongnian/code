    public class Concrete : IAbstraction
    {
        void CreateOrUpdate<T>(IList<T> tagList, IndexType indexType)
            where T : BaseInfoForRecommender
        {
             var dict = new Dictionary<Type, Action<IList<object>, IndexType>()
             {
                 { typeof(TagInfoForRecommender),
                     (tagList, indexType) => CreateOrUpdateTagInfoForRecommender(list.Cast<TagInfoForRecommender>(), index) },
                 { typeof(ArtifactInfoForRecommender),
                     (tagList, indexType) => CreateOrUpdateArtifactInfoForRecommender(list.Cast<ArtifactInfoForRecommender>(), index) },
                 { typeof(UserInfoForRecommender),
                     (tagList, indexType) => CreateOrUpdateUserInfoForRecommender(list.Cast<UserInfoForRecommender>(), index) },
             };
             dict[typeof(T)](tagList.Cast<object>(), indexType);
        }
        private CreateOrUpdateTagInfoForRecommender(IList<TagInfoForRecommender> tagList, IndexType indexType)
        {
        }
        private CreateOrUpdateArtifactInfoForRecommender(IList<ArtifactInfoForRecommender> tagList, IndexType indexType)
        {
        }
        private CreateOrUpdateUserInfoForRecommender(IList<UserInfoForRecommender> tagList, IndexType indexType)
        {
        }
    }
    
