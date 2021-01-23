csharp
public void SendAppToBackground(IApp app, TimeSpan timeSpan)
{
    if (OnAndroid)
    {
        return;
    }
    ((iOSApp)app).SendAppToBackground(timeSpan);
    app.Screenshot("Return from background state.");
    return this;
}
