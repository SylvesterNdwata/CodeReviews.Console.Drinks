using silvermax.DrinksInfo.Models;

namespace silvermax.DrinksInfo;

public class DrinksService
{
    private readonly DrinksClient _client;

    public DrinksService(DrinksClient drinksClient) => _client = drinksClient;
    public async Task<CategoriesResponse> GetCategories()
    {
        return await _client.GetCategories();
    }

    public async Task<DrinkResponse> GetDrinksByCategory(string category)
    {
        return await _client.GetDrinksByCategory(category);
    }

    public async Task<IndividualDrinkResponse> GetDrinkDetails(string id)
    {
        return await _client.GetDrinkDetails(id);
    }
}
