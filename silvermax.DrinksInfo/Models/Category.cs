using System.Text.Json.Serialization;

namespace silvermax.DrinksInfo.Models;

public record Category([property: JsonPropertyName("strCategory")] string Strcategory);

public record CategoriesResponse([property: JsonPropertyName("drinks")] List<Category> Categories);