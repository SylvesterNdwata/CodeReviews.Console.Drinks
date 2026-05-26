using Microsoft.Extensions.DependencyInjection;
using silvermax.DrinksInfo;
using Spectre.Console;

namespace silvermax.Drinksinfo;

static class Program
{
    public async static Task Main(string[] args)
    {
        await UserInterface.Start();
    }
}