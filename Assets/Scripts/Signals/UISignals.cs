using Extensions;
using UnityEngine.Events;

public class UISignals : MonoSingleton<UISignals>
{
    public UnityAction<int> onSetNewLevelValue = delegate { };
}
