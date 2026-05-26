using Microsoft.Extensions.DependencyInjection;
using silvermax.DrinksInfo.Models;
using Spectre.Console;

namespace silvermax.DrinksInfo;

public static class UserInterface
{
    public static async Task Start()
    {
        bool end = false;
        while (!end)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[DarkOliveGreen1_1]Welcome to the Bar[/]");
            bool drinkWasViewed = await DisplayDrinkDetails();

            if (drinkWasViewed)
                end = !AnsiConsole.Confirm("Would you like to search for another drink?");
        }

    }

    private static DrinksService GetService()
    {
        var services = new ServiceCollection();
        var serviceProvider = services.ServiceProvider();

        return serviceProvider.GetRequiredService<DrinksService>();
    }

    private static async Task<CategoriesResponse> Allcategories()
    {
        return await GetService().GetCategories();
    }
    

    private static async Task<CategoriesResponse> DisplayCategories()
    {
        var categories = await Allcategories();

        var table = new Table();
        table.Border = TableBorder.Rounded;

        table.AddColumn("[yellow]No[/]");
        table.AddColumn("[yellow]Categories[/]");

        int displayId = 1;
        foreach (var category in categories.Categories)
        {
            table.AddRow(
                displayId++.ToString(),
                $"[purple]{category.Strcategory}[/]"
                );
        }

        AnsiConsole.Write(table);

        return categories;
    }

    private static async Task<DrinkResponse> DisplayDrinksInCategory()
    {
        var categories = await DisplayCategories();

        var drinksCategory = UserInput.GetuserInputCategory(categories);

        Console.Clear();

        var drinks = await GetService().GetDrinksByCategory(drinksCategory);

        var table = new Table();
        table.Border = TableBorder.Rounded;

        table.AddColumn("[yellow]Id[/]");
        table.AddColumn("[yellow]Drink Name[/]");

        foreach (var drink in drinks.Drinks)
        {
            table.AddRow(
                $"[aqua]{drink.DrinkId}[/]",
                $"[Chartreuse2]{drink.DrinkName}[/]"
                );
        }

        AnsiConsole.Write(table);

        return drinks;
    }

    private static async Task<bool> DisplayDrinkDetails()
    {
        bool backToCategories = false;
        while (!backToCategories)
        {
            var drinks = await DisplayDrinksInCategory();

            var drinkId = UserInput.GetUserInputDrink(drinks);

            if (drinkId == "0")
            {
                backToCategories = true;
                continue;
            }

            Console.Clear();

            var drinkDetails = await GetService().GetDrinkDetails(drinkId);

            var detail = drinkDetails.Drink.First();

            var table = new Table();
            table.Border = TableBorder.Rounded;

            table.AddColumn("[yellow]Field[/]");
            table.AddColumn("[yellow]Info[/]");

            table.AddRow("[aqua]id[/]", $"[white]{detail.Id}[/]");
            table.AddRow("[aqua]Name[/]", $"[white]{detail.DrinkName}[/]");
            table.AddRow("[aqua]Category[/]", $"[white]{detail.DrinkCategory}[/]");
            table.AddRow("[aqua]Alcoholic[/]", $"[white]{detail.IsAlcoholic}[/]");
            table.AddRow("[aqua]Glass[/]", $"[white]{detail.DrinkGlass}[/]");
            table.AddRow("[aqua]Instructions[/]", $"[white]{detail.Instructions}[/]");

            foreach (var (ingredient, measure) in detail.Ingredients.Zip(detail.Measures))
            {
                table.AddRow($"[aqua]{ingredient}[/]", $"[white]{measure}[/]");
            }

            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine("Press any key to go back to categories menu");
            Console.ReadKey();
            Console.Clear();

            return true;
        }
        return false;
    }
}
