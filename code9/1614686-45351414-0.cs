        <ClaimsIdentityOptions.cs>
        /// <summary>
        /// Gets or sets the ClaimType used for the user identifier claim.
        /// </summary>
        /// <remarks>
        /// This defaults to <see cref="ClaimTypes.NameIdentifier"/>.
        /// </remarks>
        public string UserIdClaimType { get; set; } = ClaimTypes.NameIdentifier;
