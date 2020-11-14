using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetConfAPI.Data;
using NetConfAPI.Entities;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace NetConfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories() => await _context.Categories
            .ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategory), new { Id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, Category category)
        {
            var existeCat = await _context.Categories.AnyAsync(x => x.Id.Equals(id));

            if(!existeCat)
            {
                return NotFound();
            }

            _context.Update(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Categories.FindAsync(id);

            if(categoryToDelete == null)
            {
                return NotFound();
            }

            _context.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
