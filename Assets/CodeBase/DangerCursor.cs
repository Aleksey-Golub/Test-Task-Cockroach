using UnityEngine;

namespace Assets.CodeBase
{
    public class DangerCursor : MonoBehaviour
    {
        [SerializeField] private float _minSize = 0.5f;
        [SerializeField] private float _maxSize = 3f;
        [SerializeField] private Vector3 _sizeDelta = new Vector3(0.1f, 0.1f, 0.1f);

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            UpdatePosition();
            UpdateSize();
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void UpdateSize()
        {
            float yScroll = Input.mouseScrollDelta.y;

            if (yScroll == 0)
                return;

            transform.localScale += yScroll > 0 ? _sizeDelta : -_sizeDelta;

            transform.localScale = Vector3Extensions.ClampAllComponents(transform.localScale, _minSize, _maxSize);
        }

        private void UpdatePosition()
        {
            Vector3 position = _camera.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            transform.position = position;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.attachedRigidbody.TryGetComponent(out Cockroach cockroach))
            {
                cockroach.GetScared(transform.position);
            }
        }
    }
}