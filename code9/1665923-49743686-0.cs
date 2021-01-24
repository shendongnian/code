        try
        {
            JavaSystem.LoadLibrary("SDL2");
            JavaSystem.LoadLibrary("glib-2.0");
            JavaSystem.LoadLibrary("gthread-2.0");
            JavaSystem.LoadLibrary("fluidsynth");
            JavaSystem.LoadLibrary("sdl_mixer");
            JavaSystem.LoadLibrary("initmixer");
        }
        catch (UnsatisfiedLinkError e)
        {
            return e.Message;
        }
