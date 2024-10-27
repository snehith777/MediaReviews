using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaReviews.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ViewReviewsModel : PageModel
{
    private readonly AppDbContext _context;

    public ViewReviewsModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Review> Reviews { get; set; }
    public string CurrentCategory { get; set; }
    public string CurrentSort { get; set; }
    public string SearchString { get; set; }

    public async Task OnGetAsync(string sortOrder, string category, string searchString, int pageIndex = 1, int pageSize = 5)
    {
        CurrentSort = sortOrder;
        CurrentCategory = category;
        SearchString = searchString;

        IQueryable<Review> reviewsQuery = _context.Reviews.AsQueryable();

        // Filter by category
        if (!string.IsNullOrEmpty(category))
        {
            reviewsQuery = reviewsQuery.Where(r => r.Category == category);
        }

        // Filter by search string
        if (!string.IsNullOrEmpty(searchString))
        {
            reviewsQuery = reviewsQuery.Where(r => r.Title.Contains(searchString) || r.ReviewText.Contains(searchString));
        }

        // Sort
        reviewsQuery = sortOrder switch
        {
            "rating_desc" => reviewsQuery.OrderByDescending(r => r.Rating),
            "rating_asc" => reviewsQuery.OrderBy(r => r.Rating),
            "date_desc" => reviewsQuery.OrderByDescending(r => r.DateReviewed),
            "date_asc" => reviewsQuery.OrderBy(r => r.DateReviewed),
            _ => reviewsQuery.OrderBy(r => r.DateReviewed),
        };

        // Pagination
        int totalReviews = await reviewsQuery.CountAsync();
        Reviews = await reviewsQuery.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

        ViewData["TotalPages"] = (int)System.Math.Ceiling((double)totalReviews / pageSize);
        ViewData["CurrentPage"] = pageIndex;
    }
}
