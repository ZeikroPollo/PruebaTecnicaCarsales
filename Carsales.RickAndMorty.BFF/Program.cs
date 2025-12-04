using Carsales.RickAndMorty.BFF.Clients;
using Carsales.RickAndMorty.BFF.Services;
using Carsales.RickAndMorty.BFF.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// CORS: permitir llamadas desde el Angular dev server (http://localhost:4200)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IRickAndMortyApiClient, RickAndMortyApiClient>(client =>
{
    var baseUrl = builder.Configuration["RickAndMortyApi:BaseUrl"];

    if (string.IsNullOrWhiteSpace(baseUrl))
    {
        throw new InvalidOperationException("Debe configurarse RickAndMortyApi:BaseUrl en appsettings.json");
    }

    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped<IEpisodeService, EpisodeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Activa CORS con la política que definimos arriba
app.UseCors("AllowAngularDev");

app.MapEpisodeEndpoints();

app.Run();