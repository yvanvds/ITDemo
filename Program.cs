using System.Text.Json;

// de naam van het bestand
const string fileName = "library.json";

// combineer de filename met de appdata folder en de naam van het programma
var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OefeningJSON");
var filePath = Path.Combine(path, fileName);

Oefening.Models.Library? library = null;

// kijk of het bestand bestaat
if (File.Exists(filePath))
{
    // lees alle tekst uit het bestand
    string content = File.ReadAllText(filePath);

    // probeer de inhoud in de library te plaatsen
    library = JsonSerializer.Deserialize<Oefening.Models.Library>(content);
}

// er was geen bestand, of het bestand kon niet gelezen worden met JSON
if (library == null)
{
    // maak een lege library in dit geval
    library = new();
}

var creator = new Oefening.Views.Creator();
var menu = new SMUtils.Menu();

menu.AddOption('1', "Toon library details", () =>
{
    Console.WriteLine("Naam: " + library.Name);
    Console.WriteLine("Items: " + library.Items.Count);
});

menu.AddOption('2', "Voeg een game toe", () =>
{
    var game = creator.CreateGame();
    library.Items.Add(game);
});

menu.AddOption('3', "Toon Items", () => {
    Oefening.Views.Viewer.Show(library.Items);
    Console.Write("Typ ID voor meer: ");
    var result = Console.ReadLine();
    try
    {
        int i = int.Parse(result);
        if (i >= 0 && i < library.Items.Count)
        {
            Oefening.Views.Viewer.Show(library.Items[i]);
        }
    } catch { }
});

menu.AddOption('4', "Kies een library naam", () => {
    Console.Write("Naam van de library: ");
    library.Name = Console.ReadLine();
});



menu.Start();

// maak directory als die nog niet bestaat
Directory.CreateDirectory(path);

// maak of overschrijf een bestand
var writer = File.CreateText(filePath);

// voeg een optie toe om het bestand leesbaar te houden
var options = new JsonSerializerOptions
{
    WriteIndented = true
};

// schrijf content van library naar bestand
writer.Write(JsonSerializer.Serialize(library, options));

// sla het bestand op
writer.Flush();
