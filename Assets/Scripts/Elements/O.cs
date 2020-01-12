using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Vuforia;

namespace Assets.Scripts.Elements
{
    class O : MonoBehaviour, ITrackableEventHandler
    {

        void Start() { transform.GetComponent<TrackableBehaviour>().RegisterTrackableEventHandler(this); }
        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                    newStatus == TrackableBehaviour.Status.TRACKED ||
                    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();

            }
            else
            {
                OnTrackingLost();
            }
        }
        private void OnTrackingFound()
        {
            
            transform.tag = "tracking";
        }
        private void OnTrackingLost()
        {

            transform.tag = "not";
        }

    }
}
