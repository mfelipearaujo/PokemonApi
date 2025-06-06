namespace PokemonApi.Models;

public class PokemonListResponse
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public List<PokemonItem> Results { get; set; } = new();
}
