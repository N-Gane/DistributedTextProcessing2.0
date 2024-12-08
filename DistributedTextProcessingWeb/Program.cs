var builder = WebApplication.CreateBuilder(args);

// ��������� ��������� MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ��������� ������ � ������ production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=File}/{action=Index}/{id?}");

    // ��������������� � ������� ��������
    endpoints.MapGet("/", context =>
    {
        context.Response.Redirect("/File/Index");
        return Task.CompletedTask;
    });
});

app.Run();
