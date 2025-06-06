using PokemonApi.Clients;
using PokemonApi.Models;

namespace PokemonApi.Services;

public class PokemonService
{
    private readonly IPokeApi _pokeApi;

    public PokemonService(IPokeApi pokeApi)
    {
        _pokeApi = pokeApi;
    }

    public async Task<List<PokemonDto>> GetPokemonsAsync(int limit, int offset)
    {
        var listResponse = await _pokeApi.GetPokemonsAsync(limit, offset);

        var tasks = listResponse.Results.Select(async item =>
        {
            var detail = await _pokeApi.GetPokemonDetailAsync(item.Name);

            return new PokemonDto
            {
                Name = detail.Name,
                ImageUrl = detail.Sprites.Front_Default
            };
        });

        return (await Task.WhenAll(tasks)).ToList();
    }

    public async Task<PokemonDto?> GetPokemonByNameOrIdAsync(string nameOrId)
    {
        try
        {
            var detail = await _pokeApi.GetPokemonDetailAsync(nameOrId);

            return new PokemonDto
            {
                Name = detail.Name,
                ImageUrl = detail.Sprites.Front_Default
            };
        }
        catch
        {
            return null;
        }
    }
}