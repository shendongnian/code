        static bool IsSFHosted()
        {
            try
            {
                var node = FabricRuntime.GetNodeContext();
                return true;
            }
            catch (FabricConnectionDeniedException)
            {
                return false;
            }
        }
