    private static bool _TickIfAble(WeakReference<CognateBase> r)
        {
            CognateBase cb;
            if (r.TryGetTarget(out cb))
            {
                cb.Tick();
                return false;
            }
            else
            {
                return true;
            }
        }
