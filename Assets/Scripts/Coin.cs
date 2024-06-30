using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    void Start()
    {
        GameObject.Find("Player").transform.Find("Player2").gameObject.GetComponent<PlayerController>().MaxCoin++;

    }

}
