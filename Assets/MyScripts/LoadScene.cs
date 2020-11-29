namespace Mapbox.Unity.Map
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class LoadScene : MonoBehaviour
    {
        public string destinationSceneName;
        // Start is called before the first frame update
        string currScene;
        public void OnClick()
        {
            currScene = SceneManager.GetActiveScene().name;
            // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
            if (destinationSceneName != currScene)
                SceneManager.LoadScene(destinationSceneName);
        }

    }
}