using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

namespace InputWithUniRx
{
    public class TestInputControl : MonoBehaviour
    {
        public InputControl inputControl;

        void Start()
        {

            inputControl.InputStream
                .Subscribe(x => {
                    if (x == InputControlKind.Fire)
                    {
                        Debug.Log("Firing");
                    }
                    else if (x == InputControlKind.Jump)
                    {
                        Debug.Log("Jumping");
                    }
                });

        }
    }
}
