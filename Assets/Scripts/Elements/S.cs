﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Vuforia;

namespace Assets.Scripts.Elements
{
    class S: MonoBehaviour, Element, ITrackableEventHandler
    {
        public State DefaultState { get; set; }
        public List<State> States { get; set; }
        public State Current { get; set; }
        public GameObject basic;
        public GameObject SO3;
        public GameObject H3SO4;
        public GameObject oxygen;
        public GameObject hydrogenium;
        public float rotateSpeed;


        public void ChangeState(int value)
        {
            Current.Dispose();
            States[value].initState();
            Current = States[value];
        }

        void Start()
        {
            States = new List<State> { new State(basic, "S"), new State(SO3, "SO"), new State(H3SO4, "HSO") };
            DefaultState = States[0];
            Current = DefaultState;
            Current.initState();
            transform.GetComponent<TrackableBehaviour>().RegisterTrackableEventHandler(this);
        }

        void Update()
        {
            Current.activeElement.GetComponent<Transform>().Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
            if (transform.tag == "tracking")
            {
                if (hydrogenium.tag != "tracking" && oxygen.tag == "tracking")
                {
                    ChangeState(1);
                }
                else if (hydrogenium.tag == "tracking" && hydrogenium.transform.GetComponent<H>().Current.key == "OH")
                {
                    ChangeState(2);

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
