using System.Text.Json.Serialization;

namespace silvermax.DrinksInfo.Models;

public record Drink(
    [property: JsonPropertyName("strDrink")] string DrinkName, 
    [property: JsonPropertyName("strDrinkThumb")] string DrinkImage,
    [property: JsonPropertyName("idDrink")] string DrinkId
    );

public record DrinkResponse([property: JsonPropertyName("drinks")] List<Drink> Drinks);

public record IndividualDrinkResponse([property: JsonPropertyName("drinks")] List<DrinkDetails> Drink);

public record DrinkDetails(
    [property: JsonPropertyName("idDrink")] string Id,
    [property: JsonPropertyName("strDrink")] string DrinkName,
    [property: JsonPropertyName("strCategory")] string DrinkCategory,
    [property: JsonPropertyName("strAlcoholic")] string IsAlcoholic,
    [property: JsonPropertyName("strGlass")] string DrinkGlass,
    [property: JsonPropertyName("strInstructionsDE")] string Instructions,
    [property: JsonPropertyName("strIngredient1")] string? Ingredient1,
    [property: JsonPropertyName("strIngredient2")] string? Ingredient2,
    [property: JsonPropertyName("strIngredient3")] string? Ingredient3,
    [property: JsonPropertyName("strIngredient4")] string? Ingredient4,
    [property: JsonPropertyName("strIngredient5")] string? Ingredient5,
    [property: JsonPropertyName("strIngredient6")] string? Ingredient6,
    [property: JsonPropertyName("strIngredient7")] string? Ingredient7,
    [property: JsonPropertyName("strIngredient8")] string? Ingredient8,
    [property: JsonPropertyName("strIngredient9")] string? Ingredient9,
    [property: JsonPropertyName("strIngredient10")] string? Ingredient10,
    [property: JsonPropertyName("strIngredient11")] string? Ingredient11,
    [property: JsonPropertyName("strIngredient12")] string? Ingredient12,
    [property: JsonPropertyName("strIngredient13")] string? Ingredient13,
    [property: JsonPropertyName("strIngredient14")] string? Ingredient14,
    [property: JsonPropertyName("strIngredient15")] string? Ingredient15,
    [property: JsonPropertyName("strMeasure1")] string? Measure1,
    [property: JsonPropertyName("strMeasure2")] string? Measure2,
    [property: JsonPropertyName("strMeasure3")] string? Measure3,
    [property: JsonPropertyName("strMeasure4")] string? Measure4,
    [property: JsonPropertyName("strMeasure5")] string? Measure5,
    [property: JsonPropertyName("strMeasure6")] string? Measure6,
    [property: JsonPropertyName("strMeasure7")] string? Measure7,
    [property: JsonPropertyName("strMeasure8")] string? Measure8,
    [property: JsonPropertyName("strMeasure9")] string? Measure9,
    [property: JsonPropertyName("strMeasure10")] string? Measure10,
    [property: JsonPropertyName("strMeasure11")] string? Measure11,
    [property: JsonPropertyName("strMeasure12")] string? Measure12,
    [property: JsonPropertyName("strMeasure13")] string? Measure13,
    [property: JsonPropertyName("strMeasure14")] string? Measure14,
    [property: JsonPropertyName("strMeasure15")] string? Measure15,
    [property: JsonPropertyName("strCreativeCommonsConfirmed")] string? CommonsConfirmed,
    [property: JsonPropertyName("dateModified")] string? LastModified
)
{
    public IEnumerable<string> Ingredients => 
        new[]
        {
            Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5,
            Ingredient6, Ingredient7, Ingredient8, Ingredient9, Ingredient10,
            Ingredient11, Ingredient12, Ingredient13, Ingredient14, Ingredient15
        }
        .Where(i => !string.IsNullOrWhiteSpace(i))!;

    public IEnumerable<string> Measures =>
       new[]
       {
            Measure1, Measure2, Measure3, Measure4, Measure5,
            Measure6, Measure7, Measure8, Measure9, Measure10,
            Measure11, Measure12, Measure13, Measure14, Measure15
       }
       .Where(m => !string.IsNullOrWhiteSpace(m))!;
}