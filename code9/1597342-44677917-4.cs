	public class DynamicMappingBehaviorExtension : UnityContainerExtension
	{
		protected override void Initialize()
		{
			this.Context.Strategies.AddNew<DynamicMappingBuildStrategy>(UnityBuildStage.TypeMapping);
		}
	}
