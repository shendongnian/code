    [DataContract]
    public class OptimizationNodeDto : IModelWithId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember(Name = "parentId")]
        public int? ParentOptimizationNodeId { get; set; }
        [DataMember(Name = "name")]
        public string Text { get; set; }
        [DataMember(Name = "opened")]
        public bool IsOpened { get; set; }
        [DataMember(Name = "selected")]
        public SelectedStates SelectedState { get; set; }
        [DataMember]
        public List<OptimizationNodeDto> Children { get; set; }
    }
