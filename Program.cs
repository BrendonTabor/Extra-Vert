List<Plant> plantList = new List<Plant>()
{
    new Plant()
    {
        Species = "Aloe",
        LightNeeds = 5,
        AskingPrice = 5.00M,
        City = "Nashville",
        Zip = "37221",
        Sold = false
    },

    new Plant()
    {
        Species = "Fern",
        LightNeeds = 3,
        AskingPrice = 10.00M,
        City = "Portland",
        Zip = "97205",
        Sold = true
    },

    new Plant()
    {
        Species = "Cactus",
        LightNeeds = 5,
        AskingPrice = 15.00M,
        City = "Phoenix",
        Zip = "85001",
        Sold = false
    },

    new Plant()
    {
        Species = "Orchid",
        LightNeeds = 4,
        AskingPrice = 25.00M,
        City = "Miami",
        Zip = "33101",
        Sold = false
    },

    new Plant()
    {
        Species = "Bamboo",
        LightNeeds = 2,
        AskingPrice = 8.00M,
        City = "San Francisco",
        Zip = "94103",
        Sold = true
    }
    
};

Console.WriteLine("Here are some plants sucka!");

// foreach(Plant plant in plantList)
// {
//     Console.WriteLine($"{plant}");
// }

for (int i = 0; i < plantList.Count; i++)
{
    Console.WriteLine($"{i + 1}. {plantList[i].Species}");
}