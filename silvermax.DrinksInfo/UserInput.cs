using silvermax.DrinksInfo.Models;
using Spectre.Console;

namespace silvermax.DrinksInfo;

public static class UserInput
{
    public static string GetuserInputCategory(CategoriesResponse categories)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>("Choose Category: ")
            .Validate(input =>
            {
                return Validation.InCategories(input, categories)
                    ? ValidationResult.Success()
                    : ValidationResult.Error("[red]Invalid category. Please input a valid category[/]");
            }));
    }

    public static string GetUserInputDrink(DrinkResponse drinks)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>("Choose a drink by inputting the drink Id or type 0 to return to category menu: ")
            .Validate(input =>
            {
                return Validation.IsADrink(input, drinks)
                    ? ValidationResult.Success()
                    : ValidationResult.Error("[red]That drink does not exist. Please input a valid drink Id[/]");
            }));
    }
}
