public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        IUnityContainer container = new UnityContainer();
        container.RegisterType&lt;EntityCRUDWindowViewModel&gt;();
        container.RegisterType&lt;ConsumerViewModel&gt;();
        container.RegisterInstance&lt;Func&lt;Entity, EntityCRUDWindow&gt;&gt;(entity =>  new EntityCRUDWindow(){DataContext=container.Resolve&lt;EntityCRUDWindowViewModel&gt;(new ParameterOverride("entity", new InjectionParameter&lt;Entity&gt;(entity))));
    }
}
