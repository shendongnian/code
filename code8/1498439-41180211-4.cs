     <TextBlock xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
                   Grid.Column="3"
                   HorizontalAlignment="Left"
                   VerticalAlignment="Center">
            <Hyperlink NavigateUri="{Binding Email}">
                <i:Interaction.Behaviors>
                    <local:MailToBehaviour />
                </i:Interaction.Behaviors>
                <Run Text="{Binding Email}" />
            </Hyperlink>
        </TextBlock>
    public class MailToBehaviour : Behavior<Hyperlink>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.RequestNavigate += (_, __) =>
            {
                Process.Start("mailto:" + __.Uri);
                __.Handled = true;
            };
        }
    }
