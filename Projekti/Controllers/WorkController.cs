using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekti.Data;
using Projekti.Models;

[Route("api/[controller]")]
[ApiController]
public class WorkController : ControllerBase
{
    private readonly MuseumDbContext _context;

    public WorkController(MuseumDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Work>>> GetWorks()
    {
        var works = await _context.Works
            .Select(work => new Work
            {
                Id = work.Id,
                Name = work.Name,
                Artist = work.Artist,
                Description = work.Description,
                Category = work.Category,
                CreationDate = work.CreationDate,
                CreationDateText = work.CreationDateText ?? "No Date Available",
                Era = work.Era
            })
            .ToListAsync();

        return Ok(works);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Work>> GetWork(int id)
    {
        var work = await _context.Works.FindAsync(id);
        if (work == null)
        {
            return NotFound(new { Message = $"Work with ID {id} not found." });
        }

        return Ok(work);
    }

    [HttpPost]
    public async Task<ActionResult<Work>> CreateWork(Work work)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        work.Id = 0; 

        _context.Works.Add(work);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWork), new { id = work.Id }, work);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWork(int id, Work updatedWork)
    {
        if (id != updatedWork.Id)
        {
            return BadRequest(new { Message = "ID mismatch." });
        }

        var existingWork = await _context.Works.FindAsync(id);
        if (existingWork == null)
        {
            return NotFound(new { Message = $"Work with ID {id} not found." });
        }

        existingWork.Name = updatedWork.Name;
        existingWork.Artist = updatedWork.Artist;
        existingWork.Description = updatedWork.Description;
        existingWork.Category = updatedWork.Category;
        existingWork.CreationDate = updatedWork.CreationDate;
        existingWork.CreationDateText = updatedWork.CreationDateText;
        existingWork.Era = updatedWork.Era;

        _context.Entry(existingWork).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWork(int id)
    {
        var work = await _context.Works.FindAsync(id);
        if (work == null)
        {
            return NotFound(new { Message = $"Work with ID {id} not found." });
        }

        _context.Works.Remove(work);
        await _context.SaveChangesAsync();

        return Ok(new { Message = $"Work with ID {id} deleted successfully." });
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Work>>> SearchWorks([FromQuery] string field, [FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(field) || string.IsNullOrWhiteSpace(query))
        {
            return BadRequest(new { Message = "Field and query parameters are required." });
        }

        query = query.ToLower();
        IQueryable<Work> results;

        switch (field.ToLower())
        {
            case "name":
                results = _context.Works.Where(w => w.Name.ToLower().Contains(query));
                break;
            case "artist":
                results = _context.Works.Where(w => w.Artist.ToLower().Contains(query));
                break;
            case "category":
                results = _context.Works.Where(w => w.Category.ToLower().Contains(query));
                break;
            case "era":
                results = _context.Works.Where(w => w.Era.ToLower().Contains(query));
                break;
            default:
                return BadRequest(new { Message = "Invalid search field." });
        }

        var filteredWorks = await results.Select(work => new Work
        {
            Id = work.Id,
            Name = work.Name,
            Artist = work.Artist,
            Description = work.Description,
            Category = work.Category,
            CreationDate = work.CreationDate,
            CreationDateText = work.CreationDateText ?? "No Date Available",
            Era = work.Era
        }).ToListAsync();

        if (!filteredWorks.Any())
        {
            return NotFound(new { Message = "No works found matching your search criteria." });
        }

        return Ok(filteredWorks);
    }
}
