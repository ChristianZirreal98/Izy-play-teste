using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsColiision : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjects;
    bool is_colision;
    [SerializeField] int multiply_score;
    [SerializeField] AudioSource effect_cut;
    [SerializeField] GameObject text_popup;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        effect_cut = GameObject.FindGameObjectWithTag("Cut").GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (is_colision)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].activeInHierarchy)
                {
                    gameObjects[i].SetActive(false);
                }
                else
                {
                    gameObjects[i].SetActive(true);
                }
            }

            is_colision = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Knife"))
        {
            if (this.gameObject.CompareTag("Colisor"))
            {
                is_colision = true;
                gameManager.Set_Get_score += 1;

                GameObject poppup = Instantiate(text_popup, gameObject.transform.position, Quaternion.identity);
                effect_cut.Play();
                Destroy(poppup, 1.0f);
            }            
            else if(this.gameObject.CompareTag("end"))
            {
                if (Time.timeScale > 0)
                {
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + (gameManager.Set_Get_score * multiply_score));
                    PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                    
                    other.gameObject.GetComponentInParent<Rigidbody>().isKinematic = true;

                    gameManager.Set_panel_wins.SetActive(true);
                    Time.timeScale = 0;
                }
            }
           
        }
        if (other.gameObject.CompareTag("Player"))
        {
           
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(2, 5, 0);
        }
    }

}
