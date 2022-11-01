using Commands;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Self Variables


    #region Public Variables

    #endregion


    #region Serialized Variables

    [SerializeField] private int totalLevelCount, levelID;
    [SerializeField] private Transform levelHolder;



    #endregion


    #region Private Variables

    private CD_Level _levelData;

    private OnLevelLoaderCommand _levelLoaderCommand;
    private OnLevelDestroyerCommand _levelDestroyerCommand;


    #endregion


    #endregion

    private void Awake()
    {
       _levelData = GetLevelData();
        levelID = GetActiveLevel();

        Init();
    }
    
    private int GetActiveLevel()
    {
        if (ES3.FileExists())
        {
            if (ES3.KeyExists("Level"))
            {
                return ES3.Load<int>(key: "Level");
            }
        }

        return 0;
    }

    private CD_Level GetLevelData() => Resources.Load<CD_Level>(path:"Data/CD_Level");

    private void Init()
    {
        _levelLoaderCommand = new OnLevelLoaderCommand(levelHolder);
        _levelDestroyerCommand = new OnLevelDestroyerCommand(levelHolder);
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onLevelInitialize += _levelLoaderCommand.Execute(levelID);
        CoreGameSignals.Instance.onClearActiveLevel += _levelDestroyerCommand.Execute;
        CoreGameSignals.Instance.onNextLevel += OnInitializeLevel;
        CoreGameSignals.Instance.onRestartLevel += OnInitializeLevel;
    }

    private void UnSubscribeEvents()
    {
        CoreGameSignals.Instance.onLevelInitialize -= _levelLoaderCommand.Execute(levelID);
        CoreGameSignals.Instance.onClearActiveLevel -= _levelDestroyerCommand.Execute;
        CoreGameSignals.Instance.onNextLevel -= OnInitializeLevel;
        CoreGameSignals.Instance.onRestartLevel -= OnInitializeLevel;
    }

    private voide OnDisable()
    {
        UnSubscribeEvents();
    }

    private void Start()
    {
        __levelLoaderCommand Execute(levelID);
    }

    private void OnNextLevel()
    {
        _levelID++;
        CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
        CoreGameSignals.Instance.onReset?.Invoke();
        CoreGameSignals.Instance.onLevelInitialize?.Invoke(levelID);
    }

    private void OnRestartLevel()
    {
        
        CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
        CoreGameSignals.Instance.onReset?.Invoke();
        CoreGameSignals.Instance.onLevelInitialize?.Invoke(levelID);
    }


   
}
