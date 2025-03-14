var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Seguridad: Activa HTTP Strict Transport Security (HSTS)
}

app.UseHttpsRedirection(); // Redirige HTTP a HTTPS
app.UseStaticFiles(); // Habilita el uso de archivos estáticos (CSS, JS, imágenes, etc.)
app.UseRouting(); // Habilita el enrutamiento
app.UseAuthorization(); // Manejo de autorizaciones

// Definir las rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Credito}/{action=Solicitar}/{id?}" // Ruta por defecto: CreditoController -> Solicitar
);

app.Run(); // Inicia la aplicación
