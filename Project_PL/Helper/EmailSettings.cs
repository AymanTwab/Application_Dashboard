﻿using System.Net;
using System.Net.Mail;

namespace Project_PL.Helper
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("aymantwab@gmail.com", "tebczvfpkgdmpixm");
            client.Send("aymantwab@gmail.com", email.To, email.Title, email.Body);
        }
    }
}
