using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster _instance;
    public static GameMaster Instance => _instance;

    [SerializeField] private GameSession _gameSession;
    [SerializeField] private Player _player;

    public static GameSession GameSession => _instance._gameSession;
    public static Player Player => _instance._player;

    private void Awake()
    {
        _instance = this;

        DontDestroyOnLoad(this);
        
    }
}
