using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject button;
    [SerializeField] private GameObject ButtonPrefab;
    [SerializeField] private Transform Content;
    void Start()
    {
        if(!PlayerPrefs.HasKey("OpenLevels"))PlayerPrefs.SetInt("OpenLevels",1);
        for (int i = 1; i < PlayerPrefs.GetInt("OpenLevels") + 1; i++){
            button = Instantiate(ButtonPrefab , Content);
            button.GetComponent<Button>().onClick.AddListener(()=>SceneManager.LoadScene(1));
            button.GetComponentInChildren<Text>().text = i.ToString();
            PlayerPrefs.SetInt("PanelsNumber",i);
        }
    }
}
