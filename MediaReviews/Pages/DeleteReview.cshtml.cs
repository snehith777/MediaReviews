using MediaReviews.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class DeleteReviewModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteReviewModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Review Review { get; set; }

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
        if (Review == null)
        {
            return NotFound();
        }

        _context.Reviews.Remove(Review);
        await _context.SaveChangesAsync();
        return RedirectToPage("/ViewReviews");
    }
}
