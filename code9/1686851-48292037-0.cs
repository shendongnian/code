            protected virtual async Task<SignInResult> PreSignInCheck(TUser user)
            {
                if (!await CanSignInAsync(user))
                {
                    return SignInResult.NotAllowed;
                }
                if (await IsLockedOut(user))
                {
                    return await LockedOut(user);
                }
                return null;
    }
