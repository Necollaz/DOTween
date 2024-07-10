using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    private enum ChangeMode { Replace, Add, EffectReplace }

    [SerializeField] private Text _text;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private string[] _message;

    private string _initialText = "";

    private void Start()
    {
        if (_text != null && _message.Length > 0)
        {
            _initialText = _text.text;
            Changed();
        }
    }

    private void Changed()
    {
        Sequence sequence = DOTween.Sequence();

        for (int i = 0; i < _message.Length; i++)
        {
            string message = _message[i];
            ChangeMode changeMode = (ChangeMode)(i % 3);

            switch (changeMode)
            {
                case ChangeMode.Replace:
                    sequence.Append(_text.DOText(message, _duration));
                    break;

                case ChangeMode.Add:
                    sequence.Append(_text.DOText(_text.text + message, _duration));
                    break;

                case ChangeMode.EffectReplace:
                    sequence.Append(_text.DOText(message, _duration, true, ScrambleMode.All));
                    sequence.Join(_text.DOColor(Color.red, _duration));
                    break;
            }

            if (i % 3 == 2)
            {
                sequence.AppendCallback(Reset);
                sequence.AppendInterval(_duration);
            }
        }

        sequence.SetLoops(-1);
    }

    private void Reset()
    {
        _text.text = _initialText;
        _text.color = Color.black;
    }
}
