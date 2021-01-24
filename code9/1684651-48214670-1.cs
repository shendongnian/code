    var results = _userRoleMappingRepository.SearchFor(e => e.UserId == id)
                                                                .Select(s => new
                                                                {
                                                                    s.UserId,
                                                                    s.UserRoleId,
                                                                    s.UserRole.RoleName
                                                                })
                                                               .FirstOrDefault();
