using MediaReviews.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AddReviewModel : PageModel
{
    private readonly AppDbContext _context;

    public AddReviewModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Review Review { get; set; }

    public List<string> Categories { get; set; } = new List<string> { "Movie", "Book", "Game" };

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Review.DateReviewed = DateTime.UtcNow;
        _context.Reviews.Add(Review);
        await _context.SaveChangesAsync();
        return RedirectToPage("/ViewReviews");
    }
}
