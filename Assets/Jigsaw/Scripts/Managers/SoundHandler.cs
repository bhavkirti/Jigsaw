using Jigsaw.Scripts.Utility;
using UnityEngine;

namespace Jigsaw.Scripts.Managers
{
    public class SoundHandler : MonoBehaviour
    {
        [SerializeField] private AudioClip levelComplete;
        [SerializeField] private AudioClip incorrectPiecePlacement;
        [SerializeField] private AudioClip correctPiecePlacement;
        
        public AudioSource source;

        private void LevelComplete()
        {
            source.PlayOneShot(levelComplete);
        }

        private void IncorrectPiecePlaced()
        {
            source.PlayOneShot(incorrectPiecePlacement);
        }

        private void CorrectPiecePlaced()
        {
            source.PlayOneShot(correctPiecePlacement);
        }

        private void Awake()
        {
            EventsHandler.onLevelComplete += LevelComplete;
            EventsHandler.onIncorrectPiecePlacement += IncorrectPiecePlaced;
            EventsHandler.onCorrectPiecePlacement += CorrectPiecePlaced;
        }

        private void OnDestroy()
        {
            EventsHandler.onLevelComplete -= LevelComplete;
            EventsHandler.onIncorrectPiecePlacement -= IncorrectPiecePlaced;
            EventsHandler.onCorrectPiecePlacement -= CorrectPiecePlaced;
        }
    }
}