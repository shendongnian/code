    public class MyDomainService:IMyDomainService
    {
        public void MyFillAll(Admin_Panel adminPanel)
        {
            using (var lobo = new GymProEntities())
            {                         
                    _adminPanelArgs.ADMIN_PANEL = lobo.ADMIN_PANEL.ToList();
                    OnOnFillCompleteHandler(_adminPanelArgs);                           
            }
        }
    }
