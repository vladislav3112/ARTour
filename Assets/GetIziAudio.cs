using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GetIziAudio : MonoBehaviour
{
    public static AudioClip IziClip;
    public static IEnumerator GetAudioClip()
    {
        //use   unlName = System.Environment.GetEnvironmentVariable("URL_NAME"); instead
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("ftp://89.208.87.29/testaudio.mp3", AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                IziClip = DownloadHandlerAudioClip.GetContent(www);
            }
        }
    }
}