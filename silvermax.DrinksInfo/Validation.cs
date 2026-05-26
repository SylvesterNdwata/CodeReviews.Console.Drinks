using silvermax.DrinksInfo.Models;

namespace silvermax.DrinksInfo;

public static class Validation
{
    public static bool InCategories(string input, CategoriesResponse response)
    {
        return response.Categories.Any(c => c.Strcategory.Equals(input, StringComparison.OrdinalIgnoreCase));
    }

    public static bool IsADrink(string input, DrinkResponse response)
    {
        if (input == "0") return true;
        return response.Drinks.Any(d => d.DrinkId.Equals(input));
    }
}
