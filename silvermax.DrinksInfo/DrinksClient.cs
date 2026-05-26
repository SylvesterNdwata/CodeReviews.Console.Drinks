using silvermax.DrinksInfo.Models;
using System.Net.Http.Json;

namespace silvermax.DrinksInfo;

public class DrinksClient
{
    private readonly HttpClient _httpClient;

    public DrinksClient(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<CategoriesResponse> GetCategories() => await _httpClient.GetFromJsonAsync<CategoriesResponse>("list.php?c=list")
        ?? throw new InvalidOperationException("Failed to retrieve categories from API");

    public async Task<DrinkResponse> GetDrinksByCategory(string category)
    {
        return await _httpClient.GetFromJsonAsync<DrinkResponse>($"filter.php?c={category}")
            ?? throw new InvalidOperationException("Failed to retrieve drinks in that category");
    }

    public async Task<IndividualDrinkResponse> GetDrinkDetails(string id)
    {
        return await _httpClient.GetFromJsonAsync<IndividualDrinkResponse>($"lookup.php?i={id}")
            ?? throw new InvalidOperationException("Failed to retrieve drink, it may not exist");
    }
}
