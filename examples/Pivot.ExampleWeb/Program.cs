using Pivot;
using Pivot.ExampleWeb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddRouting();
builder.Services.AddPivotServices();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddOpenApiDocument();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseOpenApi();
app.UseSwaggerUi();
app.UseReDoc(options =>
{
    options.Path = "/redoc";
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapPivotService<IProductService>("api");

app.Run();