using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

// 配置以提供非 wwwroot 目录中的静态文件
var path = Path.Combine(app.Environment.ContentRootPath, "Pages");
var options = new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(path),
    RequestPath = "/Pages"
};
app.UseStaticFiles(options);

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
