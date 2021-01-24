    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainer container)
        {
            var temp = new ContainerBuilder();
            temp.RegisterType<SavePicture_Android>().As<ISavePicture>();
            temp.RegisterType<MessageService_Android>().As<IMessageService>();
            // ... add more RegisterTypes as needed ... 
            temp.Update(container);
        }
    }
