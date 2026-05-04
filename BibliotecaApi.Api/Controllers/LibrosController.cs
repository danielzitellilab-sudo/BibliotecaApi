using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Api.Data;
using BibliotecaApi.Api.Models;

namespace BibliotecaApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly LibraryContext _context;
    public LibrosController(LibraryContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
    {
        return Ok(await _context.Libros.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Libro>> GetLibro(int id)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro == null) return NotFound();
        return libro;
    }

    [HttpPost]
    public async Task<ActionResult<Libro>> PostLibro(Libro libro)
    {
        _context.Libros.Add(libro);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLibro), new { id = libro.Id }, libro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLibro(int id, Libro libro)
    {
        if (id != libro.Id) return BadRequest();
        _context.Entry(libro).State = EntityState.Modified;
        try { await _context.SaveChangesAsync(); }
        catch (DbUpdateConcurrencyException) { if (!LibroExists(id)) return NotFound(); throw; }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLibro(int id)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro == null) return NotFound();
        _context.Libros.Remove(libro);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool LibroExists(int id) => _context.Libros.Any(e => e.Id == id);
}