/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class CustomTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
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

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS

        private Quaternion targetRotation = Quaternion.Euler(-90, 0, 0);
        private Vector3 targetPosition = new Vector3(0.5F, 0, 0);

        public void Update()
        {
            HackathonStateManager sm = HackathonStateManager.instance;

            if (sm.arrowToBeChanged)
            {
                if (sm.currentState.Equals(State.Accessibility))
                {
                    targetRotation = Quaternion.Euler(-90, 0, 180);
                    targetPosition = new Vector3(-0.5F, 0, 0);
                }
                else if (sm.currentState.Equals(State.Normal))
                {
                    targetRotation = Quaternion.Euler(-90, 0, 0);
                    targetPosition = new Vector3(0.5F, 0, 0);
                }
                HackathonStateManager.instance.arrowToBeChanged = false;
            }
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            foreach (Renderer component in rendererComponents)
            {
                component.transform.localRotation = Quaternion.Lerp(component.transform.localRotation, targetRotation, Time.deltaTime * 2.0F);
                component.transform.localPosition = Vector3.Lerp(component.transform.localPosition, targetPosition, Time.deltaTime * 2.0F);
            }
        }
    }
}