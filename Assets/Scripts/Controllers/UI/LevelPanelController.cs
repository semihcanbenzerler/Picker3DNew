using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Signals;
using DG.Tweening;
using Sirenix.OdinInspector;
public class LevelPanelController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables 

    [SerializeField] private List<TextMeshProUGUI> levelTexts = new List<TextMeshProUGUI>();
    [SerializeField] private List<Image> stageImages = new List<Image>();

    #endregion

    #endregion

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        UISignals.Instance.onSetNewLevelValue += OnSetNewLevelValue;
        UISignals.Instance.onUpdateStageColor += OnUpdateStageColor;

    }

    private void UnsubscribeEvents()
    {
        UISignals.Instance.onSetNewLevelValue -= OnSetNewLevelValue;
        UISignals.Instance.onUpdateStageColor -= OnUpdateStageColor;
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void OnSetNewLevelValue(int levelValue)
    {

        levelTexts[0].text = levelValue.ToString();
        int value = ++levelValue;
        levelTexts[1].text = value.ToString();
    }

    [Button("OnUpdateStageColor")]
    private void OnUpdateStageColor(int value)
    {
        stageImages[value].DOColor(Color.red, .35f).SetEase(Ease.Linear);
    }
}
