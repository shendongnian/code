        ///     <para>
        ///         Adds a new entity to the <see cref="DbContext" />. If the entity is not being tracked or is currently
        ///         marked as deleted, then it becomes tracked as <see cref="EntityState.Added" />.
        ///     </para>
        ///     <para>
        ///         Note that only the given entity is tracked. Any related entities discoverable from
        ///         the given entity are not automatically tracked.
        ///     </para>
