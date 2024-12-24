using Jigsaw.Scripts.Managers;
using Jigsaw.Scripts.Utility;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Jigsaw.Scripts.PuzzlePiece
{
    public class BasePuzzlePiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] public Transform targetPosition; 
        private const float SnapThreshold = 2f; 
        
        private Vector2 _dragOffset;
        private bool _isPlacedCorrectly = false;
        
        protected Vector2 StartPosition;
        
        public bool IsPlacedCorrectly => _isPlacedCorrectly;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_isPlacedCorrectly)
            {
                return;
            }
            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _dragOffset = (Vector2)transform.position - mousePosition;
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isPlacedCorrectly)
            {
                return;
            }
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = (Vector3)(mousePosition + _dragOffset);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_isPlacedCorrectly)
            {
                return;
            }
            
            
            if (Vector2.Distance(transform.position, targetPosition.position) <= SnapThreshold)
            {
                transform.position = targetPosition.position;
                _isPlacedCorrectly = true;
                EventsHandler.RaiseOnCorrectPiecePlacement();
                if (GameManager.Instance.CheckIfGameCompleted())
                {
                    EventsHandler.RaiseOnLevelComplete();
                }
            }
            else
            {
                transform.position = StartPosition;
                EventsHandler.RaiseOnIncorrectPiecePlacement();
                Handheld.Vibrate();
            }
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        
        
        public PuzzlePieceData GetSaveData()
        {
            return new PuzzlePieceData
            {
                PieceName = name,
                CurrentPosition =  transform.position,
                IsCorrectlyPlaced = _isPlacedCorrectly
            };
        }
        
        public void LoadFromSaveData(PuzzlePieceData data)
        {
            _isPlacedCorrectly = data.IsCorrectlyPlaced;
            transform.position = data.CurrentPosition;
        }
        
        
    }
}