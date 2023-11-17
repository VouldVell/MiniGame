using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Game;
using Code.Player;
using UnityEngine;

namespace UI
{
    public class UIController: IOnController, IOnUpdate
    {
        private readonly TorchPanel _panel;
        private readonly List<Water> _waterHolder;
        private readonly DeadPanel _deadPanel;
        private readonly MainMenu _mainMenu;
        private readonly PlayerView _playerView;
        private readonly List<Torch> _torches;
        private readonly End _end;
        private readonly Vector3 _spawnPosition;
        private int _lastTorch;
        private int _score;
        private bool _isScore = true;
        private int _topScore;

        public UIController(TorchPanel panel, List<Water> waterHolder, DeadPanel deadPanel, 
            MainMenu mainMenu, PlayerView playerView, List<Torch> torches, End end)
        {
            _panel = panel;
            _waterHolder = waterHolder;
            _deadPanel = deadPanel;
            _mainMenu = mainMenu;
            _playerView = playerView;
            _torches = torches;
            _end = end;

            mainMenu.Description.text =
                "Цель игры состоит в том чтобы, бегать собирать огоньки и не попадаться в воду(вода это такой полурозрачный голубой прямоугольник).";
            mainMenu.Start.onClick.AddListener(restartAndStart);
            _end.OnTriggered += Dead;
        }

        private void RemoveOneTorch()
        {
            if (_lastTorch > 5) _lastTorch = 5;
            _panel.Torhs[_lastTorch].enabled = false;
            _lastTorch -= 1;

            CheckDead();
        }
        private void AddOneTorch()
        {
            _lastTorch += 1;
            _panel.Torhs[_lastTorch].enabled = true;
        }


        private void CheckDead()
        {
            if (_lastTorch < 0)
            {
                Dead();
            }
        }

        private void Dead()
        {
            _waterHolder.ForEach(x => x.OnTriggered -= RemoveOneTorch);
            _torches.ForEach(x => x.OnTriggered -= AddOneTorch);
            if (_topScore < _score) _topScore = _score;
            _panel.gameObject.SetActive(false);
            _deadPanel.gameObject.SetActive(true);
            _deadPanel.TopScore.text = _topScore.ToString();
            _deadPanel.Score.text = _score.ToString();
            _deadPanel.MainMenu.onClick.AddListener((() => _mainMenu.gameObject.SetActive(true)));
            _deadPanel.Restart.onClick.AddListener(restartAndStart);
            _playerView.isDead = true;
            Time.timeScale = 0;
        }
        private async void AddScore()
        {
            _isScore = false;
            await Task.Delay(1000);
            _score += 10;
            _panel.ScoreText.text = _score.ToString();
            _isScore = true;

        }

        public void OnUpdate(float deltaTime)
        {
            if(_isScore)
                AddScore();
        }

        private void restartAndStart()
        {
            _mainMenu.gameObject.SetActive(false);
            _panel.Torhs.ForEach(x => x.enabled = true);
            _waterHolder.ForEach(x => x.OnTriggered += RemoveOneTorch);
            _torches.ForEach(x => x.OnTriggered += AddOneTorch);
            _lastTorch = _panel.Torhs.Count;
            _lastTorch--;
            _score = 0;
            _panel.ScoreText.text = _score.ToString();
            _panel.gameObject.SetActive(true);
            _deadPanel.gameObject.SetActive(false);
            _playerView.transform.position = new Vector3(-0.16f, 0.283f, 1.86f);
            _playerView.isDead = false;
            //_playerView.isGrounded = false;
            Time.timeScale = 1;
        }
    }
}