using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnHelp()
    {
        SceneManager.LoadScene("Help");
    }

    public void OnBack()
    {
        SceneManager.LoadScene("Menu");
    }

}
