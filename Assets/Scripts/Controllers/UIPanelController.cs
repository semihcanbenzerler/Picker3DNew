using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

public class UIPanelController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private List<Transform> layers = new List<Transform>();

    #endregion


    #endregion

    private void OnEnable()
    {

       SubscribeEvents();
        
    }
    
    private void SubscribeEvents()
    {

    }
    private void UnSubscribeEvents()
    {

    }

    private void OnDisable()
    {
       UnSubscribeEvents();
    }

    // [Button("OnOpenPanel")]
    private void OnOpenPanel(UIPanelTypes type, int layerPos)
    {
        Instantiate(Resources.Load<GameObject>($"Screens/{type}Panel"), layers[layerPos]);
    }
    
    // [Button("OnClosePanel")]
    private void OnClosePanel(int layerPos)
    {
        if (layers[layerPos].transform.childCount > 0) 
        Destroy(layers[layerPos].GetChild(0).gameObject);
    }

    [Button("OnCloseAllPanels")]
    private void OnCloseAllPanels()
    {
        foreach (var t in layers.Where(t => t.childCount>0))
        {
          Destroy(t.GetChild(0).gameObject);
        }
    }

}
