namespace PokemonApi.Models;

public class PokemonDetailResponse
{
    public string Name { get; set; } = string.Empty;
    public Sprites Sprites { get; set; } = new();
}

public class Sprites
{
    public string Front_Default { get; set; } = string.Empty;
}
