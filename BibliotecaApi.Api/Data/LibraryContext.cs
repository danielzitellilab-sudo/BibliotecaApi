using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Api.Models;

namespace BibliotecaApi.Api.Data;
public class LibraryContext : DbContext
{
    public DbSet<Libro> Libros { get; set; }
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
}