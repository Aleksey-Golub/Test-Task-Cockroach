using Assets.CodeBase.Infrastructure;
using Assets.CodeBase.UI.Windows;
using UnityEngine;

namespace Assets.CodeBase.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private FinishWindow _finishWindow;

        private Game _game;

        private void Start()
        {
            _finishWindow.RestartButtonClicked += () => _game.RestartLevel();
        }

        public void Counstruct(Game game)
        {
            _game = game;
        }

        public void Open(WindowId windowId)
        {
            switch (windowId)
            {
                case WindowId.FinishScreen:
                    _finishWindow.Open();
                    break;
            }
        }
    }
}