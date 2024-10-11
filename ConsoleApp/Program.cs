using ClassLibrary;

Console.OutputEncoding = System.Text.Encoding.Default;

Dictionary<string, List<string>> _adjacencyDict = new Dictionary<string, List<string>>()
{
    { "Вінницька", new List<string> { "Житомирська", "Київська", "Кіровоградська", "Черкаська", "Одеська", "Хмельницька" } },
    { "Волинська", new List<string> { "Львівська", "Рівненська" } },
    { "Дніпропетровська", new List<string> { "Полтавська", "Харківська", "Донецька", "Запорізька", "Кіровоградська", "Миколаївська" } },
    { "Донецька", new List<string> { "Луганська", "Харківська", "Запорізька", "Дніпропетровська" } },
    { "Житомирська", new List<string> { "Рівненська", "Київська", "Вінницька", "Хмельницька" } },
    { "Закарпатська", new List<string> { "Львівська", "Івано-Франківська" } },
    { "Запорізька", new List<string> { "Дніпропетровська", "Донецька", "Херсонська" } },
    { "Івано-Франківська", new List<string> { "Львівська", "Закарпатська", "Чернівецька", "Тернопільська" } },
    { "Київська", new List<string> { "Житомирська", "Вінницька", "Черкаська", "Полтавська", "Чернігівська" } },
    { "Кіровоградська", new List<string> { "Вінницька", "Дніпропетровська", "Миколаївська", "Одеська", "Черкаська", "Полтавська" } },
    { "Луганська", new List<string> { "Харківська", "Донецька" } },
    { "Львівська", new List<string> { "Волинська", "Закарпатська", "Івано-Франківська", "Тернопільська", "Рівненська" } },
    { "Миколаївська", new List<string> { "Одеська", "Кіровоградська", "Дніпропетровська", "Херсонська" } },
    { "Полтавська", new List<string> { "Київська", "Черкаська", "Кіровоградська", "Дніпропетровська", "Харківська", "Сумська" } },
    { "Рівненська", new List<string> { "Волинська", "Львівська", "Житомирська", "Тернопільська", "Хмельницька" } },
    { "Сумська", new List<string> { "Чернігівська", "Полтавська", "Харківська" } },
    { "Тернопільська", new List<string> { "Львівська", "Івано-Франківська", "Чернівецька", "Хмельницька", "Рівненська" } },
    { "Харківська", new List<string> { "Сумська", "Полтавська", "Дніпропетровська", "Донецька", "Луганська" } },
    { "Херсонська", new List<string> { "Миколаївська", "Запорізька" } },
    { "Хмельницька", new List<string> { "Житомирська", "Вінницька", "Тернопільська", "Рівненська", "Чернівецька" } },
    { "Черкаська", new List<string> { "Київська", "Вінницька", "Кіровоградська", "Полтавська" } },
    { "Чернігівська", new List<string> { "Київська", "Сумська" } },
    { "Одеська", new List<string> { "Вінницька", "Кіровоградська", "Миколаївська" } },
    { "Чернівецька", new List<string> { "Івано-Франківська", "Тернопільська", "Хмельницька" } }
};

Console.WriteLine("Hill climbing (h), backtracking (b)");
string algoType = Console.ReadLine();
Algo algo = algoType == "h" ? new HillClimbing(_adjacencyDict, 100) : new Backtracking(_adjacencyDict);

Dictionary<string, string> result = algo.Start();

foreach(string region in result.Keys)
{
    Console.WriteLine($"{region} - {result[region]}");
}

Console.WriteLine($"{algo.steps} {algo.deadends} {algo.generatedStates} {algo.maxStatesInMemory} - {algo.CountConflicts()}");

/*
int iter = 20;
int totalSteps = 0;
int totalDeadends = 0;
int totalGeneratedStates = 0;
int totalMaxStatesInMemory = 0;

using (StreamWriter file = new StreamWriter("hill_climbing_results.txt"))
{
    HillClimbing hillClimbing;

    for (int i = 0; i < iter; i++)
    {
        hillClimbing = new HillClimbing(_adjacencyDict, 100);
        hillClimbing.Start();
        file.WriteLine($"{hillClimbing.steps} {hillClimbing.deadends} {hillClimbing.generatedStates} {hillClimbing.maxStatesInMemory}");
        totalSteps += hillClimbing.steps;
        totalDeadends += hillClimbing.deadends;
        totalGeneratedStates += hillClimbing.generatedStates;
        totalMaxStatesInMemory += hillClimbing.maxStatesInMemory;
    }

    file.WriteLine($"Med values: {totalSteps / iter} {totalDeadends / iter} {totalGeneratedStates / iter} {totalMaxStatesInMemory / iter}");
}

iter = 20;
totalSteps = 0;
totalDeadends = 0;
totalGeneratedStates = 0;
totalMaxStatesInMemory = 0;

using (StreamWriter file = new StreamWriter("backtracking_results.txt"))
{
    Backtracking backtracking;

    for (int i = 0; i < iter; i++)
    {
        backtracking = new Backtracking(_adjacencyDict);
        backtracking.Start();
        file.WriteLine($"{backtracking.steps} {backtracking.deadends} {backtracking.generatedStates} {backtracking.maxStatesInMemory}");
        totalSteps += backtracking.steps;
        totalDeadends += backtracking.deadends;
        totalGeneratedStates += backtracking.generatedStates;
        totalMaxStatesInMemory += backtracking.maxStatesInMemory;
    }

    file.WriteLine($"Med values: {totalSteps / iter} {totalDeadends / iter} {totalGeneratedStates / iter} {totalMaxStatesInMemory / iter}");
}
*/