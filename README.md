# BibliotecaApi

API RESTful para la gestión de libros de biblioteca, desarrollada en .NET 8 con Entity Framework Core y SQL Server.

## Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 8
- SQL Server (LocalDB para desarrollo)
- xUnit (pruebas unitarias)

## Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server o SQL Server LocalDB (incluido con Visual Studio)

> ⚠️ **Nota**: este proyecto requiere SQL Server o SQL Server LocalDB para ejecutarse. No es compatible con GitHub Codespaces sin configuración adicional.

## Configuración y ejecución

### 1. Clonar el repositorio

```bash
git clone https://github.com/danielzitellilab-sudo/BibliotecaApi.git
cd BibliotecaApi
```

### 2. Configurar la cadena de conexión

En `appsettings.json`, ajustá la cadena de conexión según tu entorno:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BibliotecaDb;Trusted_Connection=true;"
  }
}
```

### 3. Aplicar migraciones

```bash
cd BibliotecaApi.Api
dotnet ef database update
```

### 4. Ejecutar la API

```bash
dotnet run
```

La API estará disponible en `http://localhost:5000`.  
La documentación Swagger estará en `http://localhost:5000/swagger`.

## Endpoints

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/libros` | Obtiene todos los libros |
| GET | `/api/libros/{id}` | Obtiene un libro por ID |
| POST | `/api/libros` | Crea un nuevo libro |
| PUT | `/api/libros/{id}` | Actualiza un libro existente |
| DELETE | `/api/libros/{id}` | Elimina un libro |

## Ejemplo de uso

### Crear un libro (POST)

```bash
curl -X POST http://localhost:5000/api/libros \
  -H "Content-Type: application/json" \
  -d '{
    "titulo": "Clean Code",
    "autor": "Robert Martin",
    "isbn": "978-0-132-35088-4",
    "anioPublicacion": 2008
  }'
```

### Obtener todos los libros (GET)

```bash
curl http://localhost:5000/api/libros
```

## Modelo de datos

```json
{
  "id": 1,
  "titulo": "Clean Code",
  "autor": "Robert Martin",
  "isbn": "978-0-132-35088-4",
  "anioPublicacion": 2008
}
```

### Validaciones

- `Titulo`: requerido, máximo 200 caracteres
- `Autor`: requerido, máximo 100 caracteres
- `ISBN`: requerido, formato ISBN-13 estándar (ej: `978-0-132-35088-4`)
- `AnioPublicacion`: rango entre 1000 y 2100

## Pruebas unitarias

Las pruebas se encuentran en el proyecto `BibliotecaApi.Tests` y utilizan xUnit con una base de datos en memoria para garantizar el aislamiento.

### Ejecutar las pruebas

```bash
cd BibliotecaApi.Tests
dotnet test
```

### Prueba implementada

**`GetLibros_ReturnsSuccess`**: verifica que el endpoint `GET /api/libros` retorna HTTP 200 con la lista de libros correctamente, usando una base de datos en memoria con datos de prueba precargados.

## Estructura del proyecto

```
BibliotecaApi/
├── BibliotecaApi.Api/
│   ├── Controllers/
│   │   └── LibrosController.cs
│   ├── Data/
│   │   └── LibraryContext.cs
│   ├── Migrations/
│   ├── Models/
│   │   └── Libro.cs
│   ├── appsettings.json
│   └── Program.cs
└── BibliotecaApi.Tests/
    └── LibrosControllerTests.cs
```
