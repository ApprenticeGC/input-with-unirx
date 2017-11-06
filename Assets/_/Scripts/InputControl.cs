using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using UniRx.Triggers;

namespace InputWithUniRx
{
    public enum InputControlKind
    {
        Jump,
        Fire
    }

    public class InputControl : MonoBehaviour
    {
        public IObservable<InputControlKind> InputStream
        {
            get
            {
                return Observable.Create<InputControlKind>(observer => {

                    Observable.EveryUpdate()
                        .Subscribe(_ => {
                            var fireInput = Input.GetKeyDown(KeyCode.Z);
                            var jumpInput = Input.GetKeyDown(KeyCode.X);

                            if (fireInput)
                            {
                                observer.OnNext(InputControlKind.Fire);
                            }

                            if (jumpInput)
                            {
                                observer.OnNext(InputControlKind.Jump);
                            }
                        });

                    return new CompositeDisposable();
                });
            }
        }
    }
}
