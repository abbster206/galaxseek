


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    //public GameObject VideoPlayer;
    //new VideoPlayer videoPlayer;

    void Start()
    {
        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameObject.Find("Main Camera");

        // VideoPlayer automatically targets the camera backplane when it is added
        // to a camera object, no need to change videoPlayer.targetCamera.
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        // Start playback. This means the VideoPlayer may have to prepare (reserve
        // resources, pre-load a few frames, etc.). To better control the delays
        // associated with this preparation one can use videoPlayer.Prepare() along with
        // its prepareCompleted event.
        videoPlayer.Play();

        if (!(videoPlayer.isPlaying))
        {
            videoPlayer.gameObject.SetActive(false);
        }
    }

   // void EndReached(UnityEngine.Video.VideoPlayer vp)
   // {
        // vp.playbackSpeed = vp.playbackSpeed / 10.0F;
      //  vp.gameObject.SetActive(false);
   // }


   // void Update()
   //{
    //    if (!(videoPlayer.isPlaying))
     //   {
   //         videoPlayer.gameObject.SetActive(false);
    //    }
   // }

}

