using Microsoft.AspNetCore.Mvc;

[HttpPost]
public IActionResult SubmitClaim(ClaimModel model, IFormFile supportingDocument)
{
    if (ModelState.IsValid)
    {
        if (supportingDocument != null && supportingDocument.Length > 0)
        {
            // Save file to server
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", supportingDocument.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                supportingDocument.CopyTo(stream);
            }
        }

        // Save claim details
        model.Status = "Pending";
        model.DateSubmitted = DateTime.Now;
        _context.Claims.Add(model);
        _context.SaveChanges();

        return RedirectToAction("Confirmation");
    }
    return View(model);
}

