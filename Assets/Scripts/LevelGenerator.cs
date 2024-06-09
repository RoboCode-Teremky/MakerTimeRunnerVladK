using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] Panels;
    public GameObject FinishPanel;
    private GameObject LastPanel;
    public Transform Map;

    public void Generate(int PanelsCount){
        for (int i = 0; i < PanelsCount; i++)
            {
                if(LastPanel != null) LastPanel = Instantiate(Panels[Random.Range(0, Panels.Length)] , LastPanel.transform.Find("NextPanelGeneratorPoint").position , Quaternion.identity, Map); //Доробити генерацію на точці
                else LastPanel = Instantiate(Panels[Random.Range(0, Panels.Length)],Map);
            }
        Instantiate(FinishPanel, LastPanel.transform.Find("NextPanelGeneratorPoint").position , Quaternion.identity, Map);
    }

    void Start()
    {
       Generate(2);
    }
}
