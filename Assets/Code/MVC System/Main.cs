using System.Collections.Generic;
using Code.Game;
using Code.Player;
using Configs;
using UI;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private ConfigsHolder _configsHolder;
    [SerializeField] private PlayerView _player;
    [SerializeField] private TorchPanel _torchPanel;
    [SerializeField] private DeadPanel _deadPanel;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private End _end;
    [SerializeField] private List<Water> _water;
    [SerializeField] private List<Torch> _torches;
    
    private Controller _controllers;

    private void Start()
    {
        Application.targetFrameRate = 60;
        _controllers = new Controller();

        new GameInit(_controllers, _configsHolder, _player, _torchPanel, 
            _water, _deadPanel, _mainMenu, _torches, _end);

        _controllers.OnStart();
    }

    private void Update()
    {
        _controllers.OnUpdate(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _controllers.OnFixedUpdate(Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        _controllers.OnLateUpdate(Time.deltaTime);
    }    
}