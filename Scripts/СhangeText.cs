using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class СhangeText : MonoBehaviour
{
    [SerializeField] private Text _text1;
    [SerializeField] private Text _text2;
    [SerializeField] private Text _text3;
    [SerializeField] private float _duration = 3f;

    private void Start()
    {
        Changed();
    }

    private void Changed()
    {
        _text1.DOText("Этот текст заменили.", _duration);
        _text2.DOText(". Этот текст дополнил.", _duration).SetRelative();
        _text3.DOText("Этот текст взломан", _duration, true, ScrambleMode.All);
        _text3.DOColor(Color.red, _duration);
    }
}
