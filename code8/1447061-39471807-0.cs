    catch (FormatException fEX)
    {
        if (MyFormatExcTimer == null) {
            MyFormatExcTimer = new Timer(1000);
            MyFormatExcTimer.elapsed += async ( sender, e ) => await HandleTimer();
            MyFormatExcTimer.start();
    }
    private static Task HandleTimer()
    {
        if (... format is still bad ...)
        {
            Message.Box("Value must be a divisisable by 1 exactly");
        }
    }
