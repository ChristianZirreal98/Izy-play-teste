using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] List<GameObject> Buttons_shop;
    [SerializeField] List<GameObject> knifes;
    public void Sell(int value) 
    {
        if (PlayerPrefs.GetInt("Score") >= value)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - value);

            if (value == 300)
            {
                Buttons_shop[0].SetActive(false);
                Buttons_shop[2].SetActive(true);
            }
            else
            {
                Buttons_shop[1].SetActive(false);
                Buttons_shop[3].SetActive(true);
            }
        }
    }

    public void Set_knife(int value)
    {
        for (int i = 0; i < knifes.Count; i++)
        {
            if (i == value)
            {
                knifes[i].SetActive(true);
            }
            else
            {
                knifes[i].SetActive(false);
            }
        }
    }
}
