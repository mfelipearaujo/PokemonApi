using PokemonApi.Clients;
using PokemonApi.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRefitClient<IPokeApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://pokeapi.co/api/v2"));

builder.Services.AddScoped<PokemonService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
