using DG.Tweening;
using UnityEngine;

public class RotateTo : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.DORotate(_rotation, _duration, RotateMode.FastBeyond360)
            .SetLoops(_repeats, _loopType);
    }
}
