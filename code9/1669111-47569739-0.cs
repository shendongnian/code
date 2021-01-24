    public class BaseViewController : UIViewController
    {
        public void ChangePage()
        {
        UIViewController lobbyViewController = Storyboard.InstantiateViewController("LobbyViewController") as LobbyViewController;
        lobbyViewController.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
        PresentViewController(lobbyViewController, true, null);
        }
    }
