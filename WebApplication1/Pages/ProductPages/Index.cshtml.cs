using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data_Access_Layer;
using WebApplication1.Models;

namespace WebApplication1.Pages.ProductPages
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data_Access_Layer.AppDbContext _context;

        public IndexModel(WebApplication1.Data_Access_Layer.AppDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
