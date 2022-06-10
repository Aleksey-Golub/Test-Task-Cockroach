using Assets.CodeBase.UI;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private UIController _uiController;
        [SerializeField] private DangerCursor _dangerCursor;
        [SerializeField] private FinishTrigger _finishTrigger;

        private SceneLoader _sceneLoader;

        private void Awake()
        {
            Initialize();
        }

        public void RestartLevel()
        {
            _sceneLoader.RestartCurrentLevel();
        }

        private void Initialize()
        {
            _sceneLoader = new SceneLoader();
            _finishTrigger.Reached += OnFinishTriggerReached;

            _uiController.Counstruct(this);
        }

        private void OnFinishTriggerReached()
        {
            _uiController.Open(WindowId.FinishScreen);
            _dangerCursor.Deactivate();
        }
    }
}