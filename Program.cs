using Microsoft.Win32.SafeHandles;

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

void listPlants()
{
for (int i = 0; i < plantList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plantList[i].Species} in {plantList[i].City} {(plantList[i].Sold ? "was sold" : "is available")} for {plantList[i].AskingPrice}");
    }
}

void addPlant()
{
    Console.WriteLine("Name your plant.");
    string name = Console.ReadLine();

    Console.WriteLine("What are the lightneeds of your plants ona  scale of 1-5.");
    int light = int.Parse(Console.ReadLine());

    Console.WriteLine("How much for the soul of a plant.");
    decimal price = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Enter the city the plant is in.");
    string city = Console.ReadLine();

    Console.WriteLine("Enter zipcode.");
    string zip = Console.ReadLine();

    Plant PlantToAdd = new Plant()
    {
        Species = name,
        LightNeeds = light,
        AskingPrice = price,
        City = city,
        Zip = zip,
        Sold = false

    };

    Console.WriteLine(@"
    Adding plant to database...
    ");

    plantList.Add(PlantToAdd);

    listPlants();
}

string choice = "";

while(choice != "e")
{
    Console.WriteLine(@"
        Please choose and option:
        a. Display all plants
        b. Post a plant to be adopted
        c. Adopt a plant
        d. Delist a plant
        e. Exit"
        );

choice = Console.ReadLine();

    switch(choice)
    {
        case "a":
            listPlants();
            break;

        case "b":
            addPlant();
            break;

        case "c":
            throw new NotImplementedException();
            // break;

        case "d":
            throw new NotImplementedException();
            break;

        case "e":
            Console.Clear();
            Console.WriteLine("Oy, fuck off.");
            break;

        default:
            Console.Clear();
            Console.WriteLine("Hey dummy, choose something bitter...");
            break;
    }
}

// foreach(Plant plant in plantList)
// {
//     Console.WriteLine($"{plant}");
// }

// for (int i = 0; i < plantList.Count; i++)
// {
//     Console.WriteLine($"{i + 1}. {plantList[i].Species}");
// }

