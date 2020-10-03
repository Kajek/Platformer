using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster _instance;
    public static GameMaster Instance => _instance;

    [SerializeField] private GameSession _gameSession;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerHealth _playerHealth;

    public static GameSession GameSession => _instance._gameSession;
    public static Player Player => _instance._player;
    public static PlayerHealth PlayerHealth => _instance._playerHealth;

    private void Awake()
    {
        _instance = this;

        DontDestroyOnLoad(this);
        
    }
}
