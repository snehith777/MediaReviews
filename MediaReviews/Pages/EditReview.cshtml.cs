using MediaReviews.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EditReviewModel : PageModel
{
    private readonly AppDbContext _context;

    public EditReviewModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Review Review { get; set; }

    public List<string> Categories { get; set; } = new List<string> { "Movie", "Book", "Game" };

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Review = await _context.Reviews.FindAsync(id);
        if (Review == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        Review.DateReviewed = DateTime.UtcNow;
        _context.Attach(Review).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToPage("/ViewReviews");
    }
}
