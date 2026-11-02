using ChatGptApp02;
using ChatGptApp02.Models;
using ChatGptApp02.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// this line ensures that the settings defined under the "OpenAI" section in your configuration files
// are loaded into an instance of the ChatOptions class, which can then be injected and used throughout
// your application. This is useful for centralizing and managing configuration settings in a structured way.

builder.Services.Configure<ChatOptions>(o => builder.Configuration.GetSection("OpenAI").Bind(o));
builder.Services.AddScoped<OpenAIService>();

await builder.Build().RunAsync();
