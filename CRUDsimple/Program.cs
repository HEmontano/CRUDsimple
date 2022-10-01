using CRUDsimple.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DB_sContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
//Obtener todos los usuarios
app.MapGet("/usuarios", (DB_sContext db) => db.Usuarios.ToList());
//Obtener usuario por id
app.MapGet("/usuarios/{id}",async (int id,DB_sContext db) =>
{
    var user = await db.Usuarios.FindAsync(id);
    if (user is null) return Results.NotFound();
    return Results.Ok(user);

});
//Crear un nuevo usuario
app.MapPost("/usuarios", async (DB_sContext db, Usuario user) =>
{
    db.Usuarios.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"usuarios/{user.IdUsuario}", user);
});
//Editar un usuario
app.MapPut("/usuarios/{id}", async (int id, DB_sContext db, Usuario Urequest) =>
{
    var user = await db.Usuarios.FindAsync(id);
    if (user is null) return Results.NotFound();
    user.Nombre = Urequest.Nombre;
    user.Apellido = Urequest.Apellido;
    user.Edad = Urequest.Edad;
    user.Ocupacion = Urequest.Ocupacion;
    user.EstadoCivil = Urequest.EstadoCivil;
    user.Cedula = Urequest.Cedula;
    await db.SaveChangesAsync();
    return Results.NoContent();

});
//Eliminar un usuario
app.MapDelete("/usuarios/{id}", async (int id, DB_sContext db)=>
{
    var user = await db.Usuarios.FindAsync(id);
    if (user is null) return Results.NotFound();
    db.Remove(user);
    await db.SaveChangesAsync();
    return Results.Ok(user);
});
app.Run();
