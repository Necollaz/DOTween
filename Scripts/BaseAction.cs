using UnityEngine;
using DG.Tweening;

public abstract class BaseAction : MonoBehaviour
{
    [SerializeField] protected float _duration;
    [SerializeField] protected int _repeats;
    [SerializeField] protected LoopType _loopType;

    private void Start()
    {
        PerformAction();
    }

    protected abstract void PerformAction();
}
