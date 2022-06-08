using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.UI.Windows
{
    public class FinishWindow : WindowBase
    {
        [SerializeField] private Button _restartButton;

        public event Action RestartButtonClicked;

        protected override void OnAwake()
        {
            _restartButton.onClick.AddListener(() =>
            {
                RestartButtonClicked?.Invoke();
            });
        }
    }
}