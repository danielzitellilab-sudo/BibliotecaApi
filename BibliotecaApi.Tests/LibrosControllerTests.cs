using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaApi.Api.Data;
using BibliotecaApi.Api.Models;
using BibliotecaApi.Api.Controllers;
using Xunit;

namespace BibliotecaApi.Tests;

public class LibrosControllerTests
{
    [Fact]
    public async Task GetLibros_ReturnsSuccess()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var context = new LibraryContext(options);
        context.Libros.Add(new Libro
        {
            Titulo = "Test Libro",
            Autor = "Test Autor",
            ISBN = "978-1-234-56789-7",
            AnioPublicacion = 2020
        });
        await context.SaveChangesAsync();

        var controller = new LibrosController(context);
        controller.ControllerContext = new ControllerContext();

        // Act & Assert
        var result = await controller.GetLibros();
        Assert.NotNull(result.Result);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var libros = Assert.IsType<List<Libro>>(okResult.Value);
        Assert.Single(libros);
    }
}