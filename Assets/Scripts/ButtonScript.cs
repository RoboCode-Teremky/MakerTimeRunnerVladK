using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public int ButtonNumber;
    public void ButtonPress(){
        PlayerPrefs.SetInt("PanelsNumber",ButtonNumber);
        SceneManager.LoadScene(1);
    }
}
