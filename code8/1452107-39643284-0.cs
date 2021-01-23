    /// <summary>
    /// Gets or sets the callback that will be called to
    /// determine whether to skip the given record or not.
    /// This overrides the <see cref="SkipEmptyRecords"/> setting.
    /// </summary>
    public virtual Func<string[], bool> ShouldSkipRecord { get; set; }
