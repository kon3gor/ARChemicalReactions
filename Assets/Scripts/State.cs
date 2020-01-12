using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class State
    {
        public GameObject activeElement;
        public String key;
        public State(GameObject objec, String keyString) {
            this.activeElement = objec;
            this.key = keyString;
        }

        public void initState() {
            activeElement.SetActive(true);
        }

        public void Dispose() {
            activeElement.SetActive(false);
        }
    }
}
