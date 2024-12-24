using System.IO;
using Jigsaw.Scripts.GameData;
using UnityEngine;

namespace Jigsaw.Scripts.Managers
{
    public class FileManager : MonoBehaviour
    {
        public static FileManager instance; 
        private string _saveFilePath ;//= "/Users/bhavkirtisharma/JigsawMiniGame/gameState.json";

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log(Application.persistentDataPath); 
                _saveFilePath = Application.persistentDataPath + "/gameState.json";
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void SaveGameState(GameStateData gameState)
        {
            string json = JsonUtility.ToJson(gameState, true);
            File.WriteAllText(_saveFilePath, json);
        }

        
        public GameStateData LoadGameState()
        {
            if (!File.Exists(_saveFilePath)) return new GameStateData();
            string json = File.ReadAllText(_saveFilePath);
            GameStateData gameState = JsonUtility.FromJson<GameStateData>(json);
            return gameState;
        }
        
    }
}