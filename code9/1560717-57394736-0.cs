    public static void DeleteRange<UnitObject>(this System.ComponentModel.BindingList<UnitObject> bindingList, IEnumerable<UnitObject> collection)
        {
            // The given collection may not be null.
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
    
            // Remember the current setting for RaiseListChangedEvents
            // (if it was already deactivated, we shouldn't activate it after adding!).
            var oldRaiseEventsValue = bindingList.RaiseListChangedEvents;
    
            // Try deleting all of the elements to the binding list.
            try
            {
                bindingList.RaiseListChangedEvents = false;
    
                foreach (var value in collection)
                    bindingList.Remove(value);
            }
    
            // Restore the old setting for RaiseListChangedEvents (even if there was an exception),
            // and fire the ListChanged-event once (if RaiseListChangedEvents is activated).
            finally
            {
                bindingList.RaiseListChangedEvents = oldRaiseEventsValue;
    
                if (bindingList.RaiseListChangedEvents)
                    bindingList.ResetBindings();
            }
        }
