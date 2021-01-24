    /// <summary>
    /// Handles the CollectionRegistering event of the BindingOperations control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="CollectionRegisteringEventArgs"/> instance containing the event data.</param>
    private void BindingOperations_CollectionRegistering(object sender, CollectionRegisteringEventArgs e)
    {
        BindingOperations.EnableCollectionSynchronization(e.Collection, e.Collection);
    }
