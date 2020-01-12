using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    interface Element
    {
        State DefaultState { get; set; }
        List<State> States { get; set; }
        State Current { get; set; }
        void ChangeState(int value);
    }
}
