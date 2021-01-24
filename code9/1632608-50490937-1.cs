    public static void GetUsers()
    {
        System.Collections.Generic.List<ARSoft.Tools.Net.Dns.SrvRecord> lsLdap = GetLdap();
        ARSoft.Tools.Net.Dns.SrvRecord ldap = lsLdap[0];
        
        string[] attrs = new string[] { "cn", "distinguishedName", "sAMAccountName", "userPrincipalName", "displayName", "givenName", "sn", "mail", "mailNickname", "memberOf", "homeDirectory", "msExchUserCulture" };
        // CN = Common Name
        // OU = Organizational Unit
        // DC = Domain Component
        string searchBase = "DC=cor,DC=local";
        string searchFilter = "(&(objectClass=user)(objectCategory=person))";
        string ldapHost = MySamples.TestSettings.ldapHost;
        int ldapPort = MySamples.TestSettings.ldapPort;//System.Convert.ToInt32(args[1]);
        string loginDN = MySamples.TestSettings.loginDN; // args[2];
        string password = MySamples.TestSettings.password; // args[3];
        Novell.Directory.Ldap.LdapConnection lc = new Novell.Directory.Ldap.LdapConnection();
        int ldapVersion = Novell.Directory.Ldap.LdapConnection.Ldap_V3;
        try
        {
            // connect to the server
            lc.Connect(ldap.Target.ToString(), ldap.Port);
            // bind to the server
            lc.Bind(ldapVersion, loginDN, password);
            Novell.Directory.Ldap.LdapSearchConstraints cons = lc.SearchConstraints;
            cons.ReferralFollowing = true;
            lc.Constraints = cons;
            // To enable referral following, use LDAPConstraints.setReferralFollowing passing TRUE to enable referrals, or FALSE(default) to disable referrals.
           Novell.Directory.Ldap.LdapSearchResults lsc = lc.Search(searchBase,
                                            Novell.Directory.Ldap.LdapConnection.SCOPE_SUB,
                                            searchFilter,
                                            attrs,
                                            false,
                                            (Novell.Directory.Ldap.LdapSearchConstraints)null);
            while (lsc.HasMore())
            {
                Novell.Directory.Ldap.LdapEntry nextEntry = null;
                try
                {
                    nextEntry = lsc.Next();
                }
                catch (Novell.Directory.Ldap.LdapReferralException eR)
                {
                    // https://stackoverflow.com/questions/46052873/ldap-referal-error
                    // The response you received means that the directory you are requesting does not contain the data you look for, 
                    // but they are in another directory, and in the response there is the information about the "referral" directory 
                    // on which you need to rebind to "redo" the search.This principle in LDAP are the referral.
                    // https://www.novell.com/documentation/developer/ldapcsharp/?page=/documentation/developer/ldapcsharp/cnet/data/bp31k5d.html
                    // To enable referral following, use LDAPConstraints.setReferralFollowing passing TRUE to enable referrals, or FALSE (default) to disable referrals.
                    // are you sure your bind user meaning
                    // auth.impl.ldap.userid=CN=DotCMSUser,OU=Service Accounts,DC=mycompany,DC=intranet
                    // auth.impl.ldap.password = mypassword123
                    // has permissions to the user that is logging in and its groups?
                    System.Diagnostics.Debug.WriteLine(eR.LdapErrorMessage);
                }
                catch (Novell.Directory.Ldap.LdapException e)
                {
                    // WARNING: Here catches only LDAP-Exception, no other types...
                    System.Console.WriteLine("Error: " + e.LdapErrorMessage);
                    // Exception is thrown, go for next entry
                    continue;
                }
                var atCN = nextEntry.getAttribute("cn");
                var atUN = nextEntry.getAttribute("sAMAccountName");
                var atDN = nextEntry.getAttribute("distinguishedName");
                var atDIN = nextEntry.getAttribute("displayName");
                if (atCN != null)
                    System.Console.WriteLine(atCN.StringValue);
                if (atUN != null)
                    System.Console.WriteLine(atUN.StringValue);
                if (atDN != null)
                    System.Console.WriteLine(atDN.StringValue);
                if (atDIN != null)
                    System.Console.WriteLine(atDIN.StringValue);
                System.Console.WriteLine("\n" + nextEntry.DN);
                Novell.Directory.Ldap.LdapAttributeSet attributeSet = nextEntry.getAttributeSet();
                System.Collections.IEnumerator ienum = attributeSet.GetEnumerator();
                while (ienum.MoveNext())
                {
                    Novell.Directory.Ldap.LdapAttribute attribute = (Novell.Directory.Ldap.LdapAttribute)ienum.Current;
                    string attributeName = attribute.Name;
                    string attributeVal = attribute.StringValue;
                    System.Console.WriteLine(attributeName + "value:" + attributeVal);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            // disconnect with the server
            lc.Disconnect();
        }
    }
