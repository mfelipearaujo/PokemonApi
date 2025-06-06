using Microsoft.AspNetCore.Mvc;
using PokemonApi.Services;
using PokemonApi.Models;

namespace PokemonApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly PokemonService _pokemonService;

    public PokemonController(PokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PokemonDto>>> Get([FromQuery] int limit = 10, [FromQuery] int offset = 0)
    {
        var result = await _pokemonService.GetPokemonsAsync(limit, offset);
        return Ok(result);
    }

    [HttpGet("{nameOrId}")]
    public async Task<ActionResult<PokemonDto>> GetById(string nameOrId)
    {
        var result = await _pokemonService.GetPokemonByNameOrIdAsync(nameOrId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
