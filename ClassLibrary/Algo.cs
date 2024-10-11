namespace ClassLibrary
{
    public abstract class Algo
    {
        protected readonly Dictionary<string, List<string>> _adjacencyDict;
        protected readonly Dictionary<string, string> _colors = new Dictionary<string, string>();
        protected readonly string[] _availableColors = { "Red", "Yellow", "Blue", "Green" };

        protected Random _random = new Random();

        public int steps = 0;
        public int deadends = 0;
        public int generatedStates = 0;
        public int maxStatesInMemory = 0;

        public Algo(Dictionary<string, List<string>> adjacencyDict)
        {
            _adjacencyDict = adjacencyDict;
        }

        public abstract Dictionary<string, string> Start();
        protected abstract void InitColors();
       
        public int CountConflicts()
        {
            int conflicts = 0;

            foreach (string region in _adjacencyDict.Keys)
            {
                foreach (string neighbourRegion in _adjacencyDict[region])
                {
                    if (_colors[region] == _colors[neighbourRegion])
                    {
                        conflicts++;
                    }
                }
            }

            return conflicts / 2;
        }
        protected string GetRandomElement(IEnumerable<string> elements)
        {
            return elements.ElementAt(_random.Next(elements.Count()));
        }
    }
}
