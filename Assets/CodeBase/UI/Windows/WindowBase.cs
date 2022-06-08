using UnityEngine;

namespace Assets.CodeBase.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        private void Awake()
        {
            OnAwake();
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        protected abstract void OnAwake();
    }
}