using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class SceneLoaderLevelSelection : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        StartCoroutine(WaitSomeTime(sceneName));   // pretty sure coroutine means it goes past the return statement in WaitSomeTime
    }

    public IEnumerator WaitSomeTime(string sceneName)
    {
        yield return new WaitForSeconds(5);     // adjust number of seconds to video length. will turn off loop once video time established
        SceneManager.LoadScene(sceneName);
    }
}