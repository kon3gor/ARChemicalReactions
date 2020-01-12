using System.Collections.Generic;
using UnityEngine;
using Vuforia;

namespace Assets.Scripts.Elements
{
    public class H : MonoBehaviour, Element, ITrackableEventHandler
    {
        public State DefaultState { get ; set; }
        public List<State> States { get; set; }
        public State Current { get; set; }
        public GameObject basic;
        public GameObject h2o;
        public GameObject oxygen;
        public float rotateSpeed;

        public void ChangeState(int value)
        {
            Current.Dispose();
            States[value].initState();
            Current = States[value];
            if (value == 1)
            {
                transform.tag = "OH";
            }
        }

        void Start()
        {
            States = new List<State> { new State(basic, "H"), new State(h2o, "OH") };
            DefaultState = States[0];
            Current = DefaultState;
            Current.initState();
            transform.GetComponent<TrackableBehaviour>().RegisterTrackableEventHandler(this);
        }

        void Update() {
            Current.activeElement.GetComponent<Transform>().Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
            if (transform.tag == "tracking")
            {
                if (transform.tag == "tracking")
                {
                    if (oxygen.tag == "tracking")
                    {
                        ChangeState(1);
                    }
                }
            }

        }

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
