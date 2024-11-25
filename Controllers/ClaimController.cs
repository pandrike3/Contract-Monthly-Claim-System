using CMCS.Data;
using Microsoft.AspNetCore.Mvc;

public class ClaimController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClaimController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Example Action
    public IActionResult Index()
    {
        var claims = _context.Claims.ToList();
        return View(claims);
        
    }
}
