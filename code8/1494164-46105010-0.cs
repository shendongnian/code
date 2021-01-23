    public static class PageExtensions
    {
        /// <summary>
        /// Recursively searches this MasterPage and its parents until it either finds a control with the given ID or
        /// runs out of parent masters to search.
        /// </summary>
        /// <param name="master">The first master to search.</param>
        /// <param name="id">The ID of the control to find.</param>
        /// <returns>The first control discovered with the given ID in a MasterPage or null if it's not found.</returns>
        public static Control FindInMasters(this MasterPage master, string id)
        {
            if (master == null)
            {
                // We've reached the end of the nested MasterPages.
                return null;
            }
            else
            {
                Control control = master.FindControl(id);
                if (control != null)
                {
                    // Found it!
                    return control;
                }
                else
                {
                    // Search further.
                    return master.Master.FindInMasters(id);
                }
            }
        }
    }
