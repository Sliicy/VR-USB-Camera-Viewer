using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WebCam : MonoBehaviour
{
    int currentCamIndex = 0;

    WebCamTexture leftEye;
    WebCamTexture rightEye;

    public RawImage displayLeft;
    public RawImage displayRight;

    public void Start()
    {
        StartStopCam_Clicked();
    }

    // Code that runs things delayed sequentially:
    //IEnumerator Test()
    //{
    //    StartStopCam_Clicked();
    //    yield return new WaitForSeconds(4);
    //    SwapCam_Clicked();
    //    yield return new WaitForSeconds(4);
    //    SwapCam_Clicked();
    //}

    public void SwapCam_Clicked()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;

            // if tex is not null:
            // stop the web cam
            // start the web cam

            if (leftEye != null && rightEye != null)
            {
                StopWebCam();
                StartStopCam_Clicked();
            }
        }
    }

    public void StartStopCam_Clicked()
    {
        if (leftEye != null && rightEye != null) // Stop the camera
        {
            StopWebCam();
        }
        else // Start the camera
        {
            //WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            //tex = new WebCamTexture(device.name);
            //display.texture = tex;
            //tex.Play();
            WebCamDevice deviceLeft = WebCamTexture.devices[1];
            leftEye = new WebCamTexture(deviceLeft.name);
            displayLeft.texture = leftEye;
            leftEye.Play();
            WebCamDevice deviceRight = WebCamTexture.devices[2];
            rightEye = new WebCamTexture(deviceRight.name);
            displayRight.texture = rightEye;
            rightEye.Play();
        }
    }

    private void StopWebCam()
    {
        displayLeft.texture = null;
        displayRight.texture = null;
        leftEye.Stop();
        leftEye = null;
        rightEye.Stop();
        rightEye = null;
    }
}
