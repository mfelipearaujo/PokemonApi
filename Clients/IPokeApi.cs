using Refit;
using PokemonApi.Models;

namespace PokemonApi.Clients;

public interface IPokeApi
{
    [Get("/pokemon")]
    Task<PokemonListResponse> GetPokemonsAsync([AliasAs("limit")] int limit, [AliasAs("offset")] int offset);

    [Get("/pokemon/{nameOrId}")]
    Task<PokemonDetailResponse> GetPokemonDetailAsync(string nameOrId);
}
