using System.ComponentModel.DataAnnotations;

namespace BibliotecaApi.Api.Models;

public class Libro
{
    public int Id { get; set; }  // PK auto-incremental por convención EF Core

    [Required(ErrorMessage = "Título es requerido")]
    [StringLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Autor { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^[0-9]{3}-[0-9]{1,5}-[0-9]{1,7}-[0-9]{1,6}-[0-9]$", ErrorMessage = "ISBN inválido (formato: 978-0-000-00000-0)")]
    public string ISBN { get; set; } = string.Empty;

    [Range(1000, 2100, ErrorMessage = "Año debe estar entre 1000 y 2100")]
    public int AnioPublicacion { get; set; }
}