    public class DSNSmtpClient : SmtpClient
    {
        public DSNSmtpClient ()
        {
        }
    
        /// <summary>
        /// Get the envelope identifier to be used with delivery status notifications.
        /// </summary>
        /// <remarks>
        /// <para>The envelope identifier, if non-empty, is useful in determining which message
        /// a delivery status notification was issued for.</para>
        /// <para>The envelope identifier should be unique and may be up to 100 characters in
        /// length, but must consist only of printable ASCII characters and no white space.</para>
        /// <para>For more information, see rfc3461, section 4.4.</para>
        /// </remarks>
        /// <returns>The envelope identifier.</returns>
        /// <param name="message">The message.</param>
        protected override string GetEnvelopeId (MimeMessage message)
        {
            // Since you will want to be able to map whatever identifier you return here to the
            // message, the obvious identifier to use is probably the Message-Id value.
            return message.MessageId;
        }
    
        /// <summary>
        /// Get the types of delivery status notification desired for the specified recipient mailbox.
        /// </summary>
        /// <remarks>
        /// Gets the types of delivery status notification desired for the specified recipient mailbox.
        /// </remarks>
        /// <returns>The desired delivery status notification type.</returns>
        /// <param name="message">The message being sent.</param>
        /// <param name="mailbox">The mailbox.</param>
        protected override DeliveryStatusNotification? GetDeliveryStatusNotifications (MimeMessage message, MailboxAddress mailbox)
        {
            // In this example, we only want to be notified of failures to deliver to a mailbox.
            // If you also want to be notified of delays or successful deliveries, simply bitwise-or
            // whatever combination of flags you want to be notified about.
            return DeliveryStatusNotification.Failure;
        }
    }
