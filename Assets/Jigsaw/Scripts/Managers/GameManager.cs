using System;
using System.Collections.Generic;
using System.Linq;
using Jigsaw.Scripts.GameData;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Jigsaw.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;

        private readonly List<PuzzlePiece.PuzzlePiece> _puzzlePieces = new ();

        [SerializeField] private List<GameObject> levels;

        private void Start()
        {
            LoadLevel();
            LoadGame();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SaveGame();
            }
        }

        private void LoadLevel()
        {
            //Load Level Based On Progress 
            Instantiate(levels[0]);
        }
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void RegisterPuzzlePiece(PuzzlePiece.PuzzlePiece piece)
        {
            if (!_puzzlePieces.Contains(piece))
            {
                _puzzlePieces.Add(piece);
            }
        }
        
        public void UnregisterPuzzlePiece(PuzzlePiece.PuzzlePiece piece)
        {
            if (_puzzlePieces.Contains(piece))
            {
                _puzzlePieces.Remove(piece);
            }
        }
        
        public void SaveGame()
        {
            GameStateData gameState = new GameStateData();
            foreach (var piece in _puzzlePieces)
            {
                gameState.pieces.Add(piece.GetSaveData());
            }

            gameState.isGameOver = CheckIfGameCompleted();

            FileManager.instance.SaveGameState(gameState);
        }
        
        private void LoadGame()
        {
            GameStateData gameState = FileManager.instance.LoadGameState();
            if (gameState.isGameOver)
            {
                return;
            }
            foreach (var pieceData in gameState.pieces)
            {
                PuzzlePiece.PuzzlePiece piece = _puzzlePieces.Find(p => p.name == pieceData.PieceName);
                if (piece != null)
                {
                    piece.LoadFromSaveData(pieceData);
                }
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                SaveGame();
            }
        }

        public bool CheckIfGameCompleted()
        {
            return _puzzlePieces.All(pieceData => pieceData.IsPlacedCorrectly);
        }
        
    }
}