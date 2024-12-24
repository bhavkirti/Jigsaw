using System.Collections.Generic;

namespace Jigsaw.Scripts.GameData
{
    
    [System.Serializable]
    public class GameStateData
    {
        public List<PuzzlePieceData> pieces = new List<PuzzlePieceData>();
        public bool isGameOver = false;
    }
}