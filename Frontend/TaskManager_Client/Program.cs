using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using TaskManager_Client.Clients;
using TaskManager_Client.Components;
using TaskManager_Client.Services;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// add backend
var backendApiUrl = builder.Configuration["backendApiUrl"];

// services
builder.Services.AddLogging();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddHttpClient<AuthClient>(client => client.BaseAddress = new Uri(backendApiUrl));
builder.Services.AddHttpClient<TasksClient>(client => client.BaseAddress = new Uri(backendApiUrl));
builder.Services.AddHttpClient<UsersClient>(client => client.BaseAddress = new Uri(backendApiUrl));

builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthStateProvider>());

builder.Services.AddAuthorizationCore();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();