using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using MudBlazorData.Data;
using MudBlazorUI.Components;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddBlazoredSessionStorage();
//builder.Services.AddBlazoredSessionStorage(config => {
//    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
//    config.JsonSerializerOptions.IgnoreNullValues = true;
//    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
//    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
//    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
//    config.JsonSerializerOptions.WriteIndented = false;
//}
//);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseEmbeddedBlazorContent(typeof(MudBlazor.Components).Assembly);
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
//app.UseEndpoints(_endpoints =>
//{
//    _endpoints.MapBlazorHub();
//    _endpoints.MapFallbackToPage("/Host");
//});
app.Run();
