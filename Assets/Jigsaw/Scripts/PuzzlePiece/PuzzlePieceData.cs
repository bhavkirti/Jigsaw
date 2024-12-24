using UnityEngine;

namespace Jigsaw.Scripts
{
    
    [System.Serializable]
    public class PuzzlePieceData
    {
        public string PieceName;     
        public Vector2 CurrentPosition; 
        public bool IsCorrectlyPlaced;
    }
}