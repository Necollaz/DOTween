using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class СhangeText : MonoBehaviour
{
    private enum ChangeMode { Replace, Add, EffectReplace }

    [SerializeField] private Text _text;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private string[] _message;

    private int _currentIndex = 0;
    private string _initialText = "";

    private void Start()
    {
        if(_text != null && _message.Length > 0)
        {
            _initialText = _text.text;
            StartCoroutine(ChangedText());
        }
    }

    private IEnumerator ChangedText()
    {
        while (true)
        {
            var wait = new WaitForSeconds(_duration);
            string message = _message[_currentIndex % _message.Length];
            ChangeMode changeMode = (ChangeMode)(_currentIndex % 3);

            switch(changeMode)
            {
                case ChangeMode.Replace:
                    ReplaceText(message);
                    break;

                case ChangeMode.Add:
                    AddText(message);
                    break;

                case ChangeMode.EffectReplace:
                    EffectReplaceText(message);
                    break;
            }

            yield return wait;
            _currentIndex++;

            if (_currentIndex % 3 == 0)
            {
                yield return wait;
                ResetText();
            }
        }
    }

    private void ReplaceText(string message)
    {
        _text.DOText(message, _duration);
    }

    private void AddText(string message)
    {
        _text.DOText(_text.text + message, _duration);
    }

    private void EffectReplaceText(string message)
    {
        _text.DOText(message, _duration, true, ScrambleMode.All);
        _text.DOColor(Color.red, _duration);
    }

    private void ResetText()
    {
        _text.text = _initialText;
        _text.color = Color.black;
    }
}