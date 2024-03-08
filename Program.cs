using mvc;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

//Agreg el soport para MySql
builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("DataContext")!);
//Agrega la funcionalidad de MVC
builder.Services.AddControllersWithViews();

//Agrega la funcionalidad MVC
builder.Services.AddScoped<IDataContext, DataContext>();

//Construye la aplicación web
var app = builder.Build();


//Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    //En caso de error en producción, oculta los errores y manda a una pagina personalizada
    app.UseExceptionHandler("/Home/Error");
    //Establece que la aplicación debe ejecutarse en HTTPS
    app.UseHsts();
}

//redirige a HTTPS
app.UseHttpsRedirection();
//utiliza rutas para los endpoints de los controladores
app.UseRouting();

//Establece el patron de rutas
app.MapControllerRoute(
    name: "defaul",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

