using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
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
        Sold = false,
        AvailableUntil = new DateTime(2024, 7, 23)
    },

    new Plant()
    {
        Species = "Fern",
        LightNeeds = 3,
        AskingPrice = 10.00M,
        City = "Portland",
        Zip = "97205",
        Sold = true,
        AvailableUntil = new DateTime(2025, 05, 12)
    },

    new Plant()
    {
        Species = "Cactus",
        LightNeeds = 5,
        AskingPrice = 15.00M,
        City = "Phoenix",
        Zip = "85001",
        Sold = false,
        AvailableUntil = new DateTime(2027, 11, 22)
    },

    new Plant()
    {
        Species = "Orchid",
        LightNeeds = 4,
        AskingPrice = 25.00M,
        City = "Miami",
        Zip = "33101",
        Sold = false,
        AvailableUntil = new DateTime(2025, 01, 05)
    },

    new Plant()
    {
        Species = "Bamboo",
        LightNeeds = 2,
        AskingPrice = 8.00M,
        City = "San Francisco",
        Zip = "94103",
        Sold = true,
        AvailableUntil = new DateTime(2026, 12, 03)
    }
    
};

Random random = new Random();

Console.WriteLine("Here are some plants sucka!");

string PlantDetails(Plant plant)
{
    string plantString = $"{plant.Species} in {plant.City} {(plant.Sold ? "was sold" : "is available")} for {plant.AskingPrice}";

    return plantString;
}

void listPlants()
{
for (int i = 0; i < plantList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {PlantDetails(plantList[i])}");
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

    DateTime date = new DateTime();
    bool validInput = false;


    // Create a variable to hold input
    while(!validInput)
    {
        Console.WriteLine(@"
        Enter a date your plant will be available until.
        ");
        try{
            date = DateTime.Parse(Console.ReadLine());
            validInput = true;
        }
        catch(FormatException ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine(@"
            Please enter a date in the following format MM/DD/YYYY!
            ");
        }
    }
    // while variable is false
    // check the date format
    // error check using try/catch
    // check the date format
    // if correct set inut variable
    // if incorrect prompt user to enter correct format

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

void AdoptPlant()
{
    for(int i = 0; i < plantList.Count; i++)
    {
        if(!plantList[i].Sold && plantList[i].AvailableUntil > DateTime.Now)
        {
            Console.WriteLine($"{i}. {plantList[i].Species}");
        }
    }
    //WriteLine choose something
    Console.WriteLine(@"
    Please choose a plant to adopt.
    ");

    //Readline and store the input
    int choice = int.Parse(Console.ReadLine());

    //Change sold prop
    plantList[choice].Sold = true;

    //Give user feedback
    Console.WriteLine($"Congratulations you've adopted a {plantList[choice].Species}. Carry on...");
}

void DeletePlant()
{
    listPlants();

    Console.WriteLine("Which plant do you want to delete");

    int choice = int.Parse(Console.ReadLine());

    plantList.RemoveAt(choice -1);

    Console.WriteLine("Delete successful!");
}

int getRandomIndex(int len)
{
    return random.Next(len);
}

void ListRandomPlant()
{
    int length = plantList.Count;
    int randomIndex = getRandomIndex(length);

    //Check first index
    while(plantList[randomIndex].Sold != false)
    {
        randomIndex = getRandomIndex(length);      
    }

    Console.WriteLine($"{plantList[randomIndex].Species} in {plantList[randomIndex].City}, has a {plantList[randomIndex].LightNeeds} on the lightscale and costs {plantList[randomIndex].AskingPrice} to adopt.");
    //if index plant is sold
    //
}

void SearchPlants()
{
    Console.WriteLine(@"
    Enter the maximum light requirement or your plant.
    ");
    int choice = int.Parse(Console.ReadLine());

    foreach (Plant plant in plantList)
    {
        if (plant.LightNeeds <= choice)
        {
            Console.WriteLine($"{plant.Species}");
        }
    }
}

string GetLowestPriced()
{
    Plant lowestPriced = null;
    decimal lowestPrice = 1000.00M;

    foreach(Plant plant in plantList)
    {
        if(plant.AskingPrice < lowestPrice)
        {
            lowestPrice = plant.AskingPrice;
            lowestPriced = plant;
        }
    }

    return lowestPriced.Species;
}

int GetTotalNumberPlants()
{  
    int counter = 0;
    foreach(Plant plant in plantList)
    {
        if(!plant.Sold && plant.AvailableUntil > DateTime.Now)
        {
            counter++;
        }
    }

    return counter;
    
}

string GetHighestLightNeedPlant()
{
    Plant highestLightNeed = null;

    int lightNeed = 0;

    foreach(Plant plant in plantList)
    {
        if(plant.LightNeeds > lightNeed)
        {
            highestLightNeed = plant;
            lightNeed = plant.LightNeeds;
        }
    }
    
    return highestLightNeed.Species;
}

int GetAverageLightNeed()
{
    int counter = 0;

    foreach(Plant plant in plantList)
    {
        counter += plant.LightNeeds;
    }
    
    int average = counter / plantList.Count;

    return average;
}

double GetPercentageAdopted()
{
    int numberAdopted = 0;
    foreach(Plant plant in plantList)
    {
        if(plant.Sold)
        {
            numberAdopted++;
        }
    }

    double percentage = ((double)numberAdopted / plantList.Count * 100);
    return percentage;
}


void ViewStatistics()
{
    string lowestPriced = GetLowestPriced();
    int totalPlants = GetTotalNumberPlants();
    string highestLightNeeded = GetHighestLightNeedPlant();
    int averageLightNeed = GetAverageLightNeed();
    double percentageAdopted = GetPercentageAdopted();

    Console.WriteLine(@$"Here are some plant statistics,
    1. {lowestPriced} is the lowest priced plant.
    2. There are a total of {totalPlants} plants listed for adoption.
    3. {highestLightNeeded} is the plant with the most light need.
    4. The average light need is {averageLightNeed}.
    5. {percentageAdopted}% of plants listed are adopted.
    ");
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
        e. See random plant of the day
        f. Search plants
        g. View Statistics 
        h. Exit
        ");

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
            AdoptPlant();
            break;

        case "d":
            DeletePlant();
            break;

        case "e":
            ListRandomPlant();
            break;

        case "f":
            SearchPlants();
            break;

        case "g":
            ViewStatistics();
            break;

        case "h":
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

