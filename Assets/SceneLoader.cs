using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private AsyncOperation asyncLoad;
    public Image loadingBar;
    public GameObject start;
    public GameObject loadingText;

    public GameObject[] dots;
    // Use this for initialization
    void Start () {
        StartCoroutine(LoadYourAsyncScene());
        StartCoroutine("ChangeDots");
    }
	
	// Update is called once per frame
	void Update () {
        if (asyncLoad.progress >= 0.85)
        {
            if (Input.anyKey)
            {
                ActivateScene();
            }
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        asyncLoad = SceneManager.LoadSceneAsync("Main");
        asyncLoad.allowSceneActivation = false;
        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            //Debug.Log(asyncLoad.progress.ToString("F3"));
            loadingBar.fillAmount = asyncLoad.progress;
            if (asyncLoad.progress >= 0.89)
            {
                loadingBar.fillAmount = 1;
                start.SetActive(true);
                loadingText.SetActive(false);
            }
            //print(asyncLoad.isDone);
            yield return null;
        }
        yield break;
    }

    public void ActivateScene()
    {
        asyncLoad.allowSceneActivation = true;
    }

    IEnumerator ChangeDots()
    {
        dots[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        dots[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        dots[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        dots[0].SetActive(false);
        dots[1].SetActive(false);
        dots[2].SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine("ChangeDots");
        yield break;
    }
}
