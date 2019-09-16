using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class GameManager
    {
        // Keyword volatile is used as a hint to the compiler that this data
        // member is accessed by multiple threads.
        private static volatile GameManager _instance;
        private static readonly object _syncLock = new object();
        private static List<int[]> winningState = new List<int[]>
        {
            new int[] { 0, 1, 2 },
            new int[] { 0, 3, 6 },
            new int[] { 0, 4, 8 },
            new int[] { 1, 4, 7 },
            new int[] { 3, 4, 5 },
            new int[] { 6, 7, 8 },
            new int[] { 2, 4, 6 },
            new int[] { 2, 5, 8 },
        };

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    lock (_syncLock)
                        if (_instance == null)
                            _instance = new GameManager();

                return _instance;
            }
        }

        public bool CheckWinCondition(int lastMove, int[] currentState)
        {
            var possibleWinState = winningState.Where(x => x.Contains(lastMove));
            foreach (var state in possibleWinState)
            {
                if (currentState[state[0]] == currentState[state[1]] && currentState[state[1]] == currentState[state[2]])
                    return true;
            }
            return false;
        }
    }
}