using UnityEngine;

namespace Levels { 
    public class Room : ScriptableObject {
        [SerializeField] private Vector3Int dimensions;
        [SerializeField] private byte[] heightMap; //values < 0 represent nonexistent terrain (inside a wall)
        
    }
}