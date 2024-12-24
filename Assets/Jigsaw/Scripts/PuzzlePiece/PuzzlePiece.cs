using Jigsaw.Scripts.Managers;

namespace Jigsaw.Scripts.PuzzlePiece
{
    public class PuzzlePiece : BasePuzzlePiece
    {
        // made this separate in case need to add level based functionality..
        private void Awake()
        {
            StartPosition = transform.position;
            GameManager.Instance.RegisterPuzzlePiece(this);
        }

        private void OnDestroy()
        {
            GameManager.Instance.UnregisterPuzzlePiece(this);
        }
    }
}