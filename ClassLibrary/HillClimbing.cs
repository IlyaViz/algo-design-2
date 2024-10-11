namespace ClassLibrary
{
    public class HillClimbing : Algo
    {
        private int _extraMoves;

        public HillClimbing(Dictionary<string, List<string>> adjacencyDict, int extraMoves) : base(adjacencyDict)
        {
            _extraMoves = extraMoves;
        }

        protected override void InitColors()
        {
            foreach (string key in _adjacencyDict.Keys)
            {
                _colors[key] = GetRandomElement(_availableColors);
            }
        }

        public bool TryImprove(string region, int currentConflicts)
        {
            steps++;

            string currentColor = _colors[region];
            List<string> sameColors = new List<string>();

            foreach (string color in _availableColors.Where(color => color != _colors[region]))
            {
                generatedStates++;

                _colors[region] = color;

                if (CountConflicts() < currentConflicts)
                {
                    return true;
                } else if (CountConflicts() == currentConflicts)
                {
                    sameColors.Add(color);
                }
            }

            if (sameColors.Count != 0)
            {
                generatedStates++;

                _colors[region] = GetRandomElement(sameColors);

                return false;
            }
            else
            {
                generatedStates++;

                _colors[region] = currentColor;

                return false;
            }

        }

        public string GetRandomRegionWithConflicts()
        {
            List<string> regionsWithConflicts = new List<string>();

            foreach (string region in _adjacencyDict.Keys)
            {
                foreach (string neighbourRegion in _adjacencyDict[region])
                {
                    if (_colors[region] == _colors[neighbourRegion])
                    {
                        regionsWithConflicts.Add(region);
                        break;
                    }
                }
            }

            return GetRandomElement(regionsWithConflicts);
        }

        private void HillClimb()
        {
            int lastConflicts = CountConflicts();
            string randomRegionWithConflicts;
            int extraMoves = 0;

            while (lastConflicts != 0 && extraMoves < _extraMoves)
            {
                randomRegionWithConflicts = GetRandomRegionWithConflicts();

                if (TryImprove(randomRegionWithConflicts, lastConflicts))
                {
                    extraMoves = 0;
                }
                else
                {
                    extraMoves++;
                }

                lastConflicts = CountConflicts();
            }
        }

        public override Dictionary<string, string> Start()
        {
            maxStatesInMemory = 2;
            deadends--;

            do
            {
                deadends++;

                InitColors();

                HillClimb();
            } while (CountConflicts() != 0);

            return _colors;
        }
    }
}
