using UnityEngine;

namespace Assets.CodeBase
{
    public class Cockroach : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _stopDistance = 0.1f;
        [SerializeField] private float _safeDistance = 2f;

        [SerializeField] private Transform _finish;

        private bool _isScared;
        private Vector3 _safePoint;

        private void Update()
        {
            Vector3 target = _isScared ? _safePoint : _finish.position;

            if (IsArrivedTo(target))
                return;

            RotateTo(target);
            MoveTo(target);
        }

        public void GetScared(Vector3 position)
        {
            if (_isScared)
                return;

            _isScared = true;
            CalculateSafePoint(position);
        }

        private void CalculateSafePoint(Vector3 dangerPosition)
        {
            Vector3 direction = (transform.position - dangerPosition).normalized;
            _safePoint = transform.position + direction * _safeDistance;
        }

        private bool IsArrivedTo(Vector3 position)
        {
            return (position - transform.position).magnitude <= _stopDistance;
        }

        private void MoveTo(Vector3 position)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * _speed);

            if (_isScared && IsArrivedTo(position))
                _isScared = false;
        }

        private void RotateTo(Vector3 position)
        {
            transform.up = position - transform.position;
        }
    }
}