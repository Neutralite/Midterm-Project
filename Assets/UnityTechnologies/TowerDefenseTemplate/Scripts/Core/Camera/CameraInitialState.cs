using System.Collections;
using UnityEngine;

namespace Core.Camera
{
	/// <summary>
	/// Simple class to set some initial state values for the camera
	/// </summary>
	[RequireComponent(typeof(CameraRig))]
	public class CameraInitialState : MonoBehaviour
	{
		public enum StartZoomMode
		{
			NoChange,
			FurthestZoom,
			NearestZoom
		}

		/// <summary>
		/// Determines the starting zoom level for the camera
		/// </summary>
		public StartZoomMode startZoomMode;
		
		/// <summary>
		/// Object for the camera to look at initially
		/// </summary>
		public Transform initialLookAt;


        /// <summary>
        /// Object for the camera to look after intial 
        /// </summary>
        public Transform endLookAt;
		
		/// <summary>
		/// On start, set camera parameters
		/// </summary>
		protected virtual void Start()
		{
			var rig = GetComponent<CameraRig>();

			switch (startZoomMode)
			{
				case StartZoomMode.FurthestZoom:
					rig.SetZoom(rig.furthestZoom);
					break;
				case StartZoomMode.NearestZoom:
					rig.SetZoom(rig.nearestZoom);
					break;
			}


			StartCoroutine(CameraPan());
			
		}


        IEnumerator CameraPan()
        {
            var rig = GetComponent<CameraRig>();

			

            if (initialLookAt != null)
            {
                 rig.PanTo(initialLookAt.transform.position);

                //yield on a new YieldInstruction that waits for 2 seconds.
                yield return new WaitForSeconds(2);


                rig.PanTo(endLookAt.transform.position);

                yield return null; 
            }
                
			

            
        }

    }
}