using Microsoft.AspNetCore.Mvc;
using CMCS.Models;
using CMCS.Data;

namespace CMCS.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                _context.Claims.Add(claim);
                _context.SaveChanges();

                return RedirectToAction("Index"); // Redirect to a list of submitted claims
            }

            return View(claim); // Return the form view if validation fails
        }

        // Other controller actions like viewing, approving, or rejecting claims would go here
    }
}

