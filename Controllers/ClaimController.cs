using Microsoft.AspNetCore.Mvc;

internal class Program
{
    private static void Main(string[] args)
    {
        [HttpPost]
        public IActionResult SubmitClaim(ClaimModel model)
        {
            if (ModelState.IsValid)
            {
                // Save to the database
                model.Status = "Pending";
                model.DateSubmitted = DateTime.Now;

                _context.Claims.Add(model);  // Assuming you have a DbSet<ClaimModel>
                _context.SaveChanges();

                return RedirectToAction("Confirmation");
            }
            return View(model);
        }

        public IActionResult UpdateClaimStatus(int claimId, string status)
        {
            var claim = _context.Claims.Find(claimId);
            if (claim != null)
            {
                claim.Status = status;
                _context.SaveChanges();
            }
            return RedirectToAction("ReviewClaims");
        }
    }
}