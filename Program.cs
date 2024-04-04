using SMS.DataContext;
using SMS.Hoang_Hieu_Hao.Service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

builder.Services.AddScoped<ManagerService>();

builder.Services.AddScoped<ManagerContext>(provider =>
{
    string filePath = "Csv-file/Manager.csv";

    return new ManagerContext(filePath);
}
);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
