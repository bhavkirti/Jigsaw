using System;

namespace Jigsaw.Scripts.Utility
{
    public abstract class EventsHandler
    {
        public static Action onLevelComplete;
        public static void RaiseOnLevelComplete()
        {
            onLevelComplete?.Invoke();
        }
        
        public static Action onIncorrectPiecePlacement;
        public static void RaiseOnIncorrectPiecePlacement()
        {
            onIncorrectPiecePlacement?.Invoke();
        }
        
        public static Action onCorrectPiecePlacement;
        public static void RaiseOnCorrectPiecePlacement()
        {
            onCorrectPiecePlacement?.Invoke();
        }
    }
}