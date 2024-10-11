namespace ClassLibrary
{
    public class Backtracking: Algo
    {
        private int currentStatesInMemory = 0;

        private string _uncolored = "uncolored";

        public Backtracking(Dictionary<string, List<string>> adjacencyDict) : base(adjacencyDict)
        {
        }

        protected override void InitColors()
        {
            foreach(string region in _adjacencyDict.Keys)
            {
                _colors[region] = _uncolored;
            }
        }

        private string RandomDGR()
        {
            List<string> availableRegions = new List<string>();

            foreach(string region in _adjacencyDict.Keys)
            {
                if (_colors[region] == _uncolored)
                {
                    availableRegions.Add(region);
                }
            }

            if (availableRegions.Count == 0)
            {
                return null;
            }

            int maxDGR = availableRegions.Select(region => _adjacencyDict[region].Count).Max();

            return GetRandomElement(availableRegions.Where(region => _adjacencyDict[region].Count == maxDGR));
        }

        private bool IsConflicting(string region)
        {
            foreach(string neighbourRegion in _adjacencyDict[region]) {
                if (_colors[region] == _colors[neighbourRegion])
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> GetShuffledAllowedColors(string region)
        {
            List<string> allowedColors = new List<string>();

            foreach(string color in _availableColors)
            {
                generatedStates++;

                _colors[region] = color;

                if (!IsConflicting(region))
                {
                    allowedColors.Add(color);
                }
            }

            generatedStates++;

            _colors[region] = _uncolored;

            return allowedColors.OrderBy(x => _random.Next()).ToList();
        }

        public bool Backtrack(string region)
        {
            currentStatesInMemory++;
            maxStatesInMemory = currentStatesInMemory > maxStatesInMemory ? currentStatesInMemory : maxStatesInMemory;

            List<string> allowedColors = GetShuffledAllowedColors(region);

            if (allowedColors.Count == 0)
            {
                currentStatesInMemory--;

                return false;
            }

            string nextRegion;

            foreach(string color in allowedColors)
            {
                steps++;
                generatedStates++;

                _colors[region] = color;
                    
                nextRegion = RandomDGR();

                if (nextRegion == null)
                {
                    return true;
                }

                if (Backtrack(nextRegion))
                {
                    currentStatesInMemory--;

                    return true;
                }
            }

            generatedStates++;

            _colors[region] = _uncolored;

            currentStatesInMemory--;

            return false;
        }

        public override Dictionary<string, string> Start()
        {
            InitColors();

            Backtrack(RandomDGR());

            return _colors;
        }
    }
}
