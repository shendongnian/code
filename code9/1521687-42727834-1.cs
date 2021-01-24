    Public Sub New()
            _context = New MyDbContext()
        End Sub
        Public Sub New(appUserMan As MyUserManager, signInMan As LoyaltySignInManager)
            UserManager = appUserMan
            SignInManager = signInMan
        End Sub
        Public Property SignInManager() As MySignInManager
            Get
                Return If(_signInManager, HttpContext.GetOwinContext().[Get](Of MySignInManager)())
            End Get
            Private Set
                _signInManager = Value
            End Set
        End Property
        Public Property UserManager() As MyUserManager
            Get
                Return If(_userManager, HttpContext.GetOwinContext().GetUserManager(Of MyUserManager)())
            End Get
            Private Set
                _userManager = Value
            End Set
        End Property
