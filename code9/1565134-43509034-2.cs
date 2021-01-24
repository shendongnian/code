    using System;
    
    using MailKit.Net.Imap;
    using MailKit.Search;
    using MailKit;
    using MimeKit;
    
    namespace GMailSearchTest {
    	class Program
    	{
    		public static void Main (string[] args)
    		{
    			using (var client = new ImapClient (new ProtocolLogger (Console.OpenStandardOutput ()))) {
    				// For demo-purposes, accept all SSL certificates
    				client.ServerCertificateValidationCallback = (s,c,h,e) => true;
    
    				client.Connect ("imap.gmail.com", 993, true);
    
    				// Note: since we don't have an OAuth2 token, disable
    				// the XOAUTH2 authentication mechanism.
    				client.AuthenticationMechanisms.Remove ("XOAUTH2");
    
    				client.Authenticate ("xxx@gmail.com", "xxx");
    
    				client.Inbox.Open (FolderAccess.ReadOnly);
    				client.Inbox.Search (SearchQuery.SubjectContains ("سلام"));
    
    				client.Disconnect (true);
    			}
    		}
    	}
    }
