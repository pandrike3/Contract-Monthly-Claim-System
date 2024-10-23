using Microsoft.AspNetCore.Mvc;
using CMCS.Models;
using CMCS.Data;
using System.Threading.Tasks; // Import Task for async methods

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
        public async Task<IActionResult> SubmitClaimAsync(Claim claim)
        {
            if (ModelState.IsValid)
            {
                // Asynchronously add the claim to the database
                await _context.Claims.AddAsync(claim);

                // Asynchronously save changes
                await _context.SaveChangesAsync();

                // Redirect to a page showing a list of submitted claims (or another page)
                return RedirectToAction("Index");
            }

            // Return the form view if validation fails
            return View(claim);
        }

        // Other asynchronous controller actions for viewing, approving, or rejecting claims can also be added here
    }
}
