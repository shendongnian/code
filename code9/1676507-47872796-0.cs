    public class HomeButton : Button, ILocale, IDisposable
    {
        public HomeButton()
        {
            UpdateContentResource();
            this.Click += (s, e) =>
            {
                KioskSession.BlockEvent(true);
                Debug.WriteLine("Customer click Home button - Return to Home ");
                MainContentSwitcher.Instance.MoveToHome();
            };
        }
    }
----------
    <menu:HomeButton 
        x:Name="BtnHome" 
        PreviewMouseDown="BtnHome_PreviewMouseDown"
        TouchDown="BtnHome_TouchDown">
        <menu:HomeButton.Style>
            <Style TargetType="menu:HomeButton">
                <Style.Triggers>
                    <Trigger Property="IsPressed" Value="true">
                        <Setter Property="Effect">
                            <Setter.Value>
                                <DropShadowEffect BlurRadius="20" ShadowDepth="0" Color="DarkBlue"/>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </menu:HomeButton.Style>
    </menu:HomeButton>
