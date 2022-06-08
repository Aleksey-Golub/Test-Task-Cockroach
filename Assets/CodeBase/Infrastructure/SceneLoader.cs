using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Infrastructure
{
    public class SceneLoader
    {
        public void RestartCurrentLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}