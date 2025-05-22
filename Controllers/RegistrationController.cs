using Microsoft.AspNetCore.Mvc;
using MimeKit;
using UserRegistration.Data;
using UserRegistration.Models;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace UserRegistration.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserDbContext _context;
        public RegistrationController(UserDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationForm form)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = form.Name,
                    Email = form.Email,
                    Password = form.Password // In a real application, hash the password before saving
                };
                _context.UserRegistrations.Add(user);
                await _context.SaveChangesAsync();

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Broad Systems Ltd.", "yourmail@gmail.com"));
                message.To.Add(new MailboxAddress(user.Name, user.Email));
                message.Subject = "Registration Success!";
                message.Body = new TextPart("html")
                {
                    Text = $@"
                     <p>Assalamualaikum <strong>{user.Name}</strong>,</p>
                     <p>Welcome to <strong>Broad Systems Ltd.</strong>!</p>
                     <p>Your registration was successful. We're excited to have you on our company <strong>Broad Systems</strong>.</p>
                     <p>Feel free to explore our services and reach out if you need any assistance.</p>
                     <br />
                     <p>Best regards,</p>
                     <p><strong>Broad Systems Ltd.</strong><br />
                     Email: ibrahimkholil01@gmail.com<br />
                     Website: <a href='https://www.facebook.com/ibrahim.khalil.0165'>www.broadsystems.com</a><br />
                     Phone: 01932878112</p>"
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false);
                    await client.AuthenticateAsync("ibrahimkholil01@gmail.com", "slez wgeq eprf jnlp ");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                TempData["SuccessMessage"] = "Registration successful! Check your email.";
                return RedirectToAction("Welcome", "Home");
            }
            return View("Index", form);

        }
    }
}
