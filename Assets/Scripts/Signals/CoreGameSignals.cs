using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoBehaviour
{
    #region Singleton

    public static CoreGameSignals Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
       // Debug.LogWarning(Instance.GetInstanceID().ToString());
    }

    #endregion

    public UnityAction<GameStates> onChangeGameState = delegate { };
    public UnityAction <int> onLevelInitialize = delegate{ };
    public UnityAction onClearActiveLevel onLevelInitialize = delegate{ };  
    public UnityAction onLevelFailed onLevelInitialize = delegate{ };
    public UnityAction onLevelSuccessful onLevelInitialize = delegate{ };
    public UnityAction onNextLevel onLevelInitialize = delegate{ };
    public UnityAction onRestartLevel onLevelInitialize = delegate{ };
    public UnityAction onReset onLevelInitialize = delegate{ };

}
