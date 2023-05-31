using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Map3", LoadSceneMode.Single);
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);*/
    }
}
