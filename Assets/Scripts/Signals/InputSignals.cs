using UnityEngine;
using UnityEngine.Events;
using Keys;
using Extensions;

namespace Assets.Scripts.Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction onEnableInput = delegate { };
        public UnityAction onDisableInput = delegate { };
        public UnityAction onFirstTimeTouchTaken = delegate { };
        public UnityAction onInputReleased = delegate { };
        public UnityAction onInputTaken = delegate { };
        public UnityAction <HorizontalInputParams> onInputDragged = delegate { };
    }
}
