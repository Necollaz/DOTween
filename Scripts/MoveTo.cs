using DG.Tweening;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        Transfer();
    }

    private void Transfer()
    {
        transform.DOMove(_position, _duration).SetLoops(_repeats, _loopType);
    }
}
