using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int level = 0;
    [SerializeField] GameObject loading_image;
    [SerializeField] Transform spawn_obj;
    [SerializeField] TextMeshProUGUI level_text;
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] List<Path> level_paths;
    bool is_spawned_end = true;
    [SerializeField] GameObject panel_wins;
    [SerializeField] GameObject panel_lose;
    public static GameManager instance;
    int random_level;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //PlayerPrefs.SetInt("Level",0);


        PlayerPrefs.SetInt("Score",0);
        level = PlayerPrefs.GetInt("Level");

        score = 0;

        random_level = PlayerPrefs.GetInt("Random_level");

        Time.timeScale = 1;
    }

    private void Update()
    {
        level_text.text = "Level : " + (level + 1).ToString();

        score_text.text = "$ " + PlayerPrefs.GetInt("Score"); 

        if (is_spawned_end)
        {
            SpawnPath();
            is_spawned_end = false;
        }
    }

    void SpawnPath()
    {
        for (int i = 0; i < level_paths.Count; i++)
        {
            if (level == i)
            {
                for (int j = 0; j < level_paths[i].Get_parts.Count; j++)
                {
                    if (level_paths[i].Get_parts[j].Get_is_long_obj)
                    {
                        Instantiate(level_paths[i].Get_parts[j].Get_obj, spawn_obj.position + level_paths[i].Get_parts[j].Get_offset_obj, Quaternion.identity);

                        spawn_obj.position = new Vector3(spawn_obj.position.x + (level_paths[i].Get_parts[j].Get_offset_obj.x - 3), spawn_obj.position.y, spawn_obj.position.z);
                    }
                    else
                    {
                        Instantiate(level_paths[i].Get_parts[j].Get_obj, spawn_obj.position, Quaternion.identity);
                        spawn_obj.position = new Vector3(spawn_obj.position.x - 3, spawn_obj.position.y, spawn_obj.position.z);

                    }
                }
            }
            else
            {
                if (random_level == 0)
                {
                     random_level = Random.Range(0, level_paths.Count);
                }
                else if (random_level == -1)
                {
                    random_level = 0;
                }

                for (int j = 0; j < level_paths[random_level].Get_parts.Count; j++)
                {
                    if (level_paths[random_level].Get_parts[j].Get_is_long_obj)
                    {
                        Instantiate(level_paths[random_level].Get_parts[j].Get_obj, spawn_obj.position + level_paths[random_level].Get_parts[j].Get_offset_obj, Quaternion.identity);

                        spawn_obj.position = new Vector3(spawn_obj.position.x + (level_paths[random_level].Get_parts[j].Get_offset_obj.x - 3), spawn_obj.position.y, spawn_obj.position.z);
                    }

                    else
                    {
                        Instantiate(level_paths[random_level].Get_parts[j].Get_obj, spawn_obj.position, Quaternion.identity);
                        spawn_obj.position = new Vector3(spawn_obj.position.x - 3, spawn_obj.position.y, spawn_obj.position.z);

                    }

                    
                }

                break;
            }

           
        }
    }

    public void Next_level()
    {
        loading_image.SetActive(true);
        PlayerPrefs.SetInt("Random_level", 0);
        SceneManager.LoadScene(0);
    }

    public void Retry_level()
    {
        loading_image.SetActive(true);
        if (random_level == 0)
        {
            PlayerPrefs.SetInt("Random_level", -1);

        }
        else
        {
            PlayerPrefs.SetInt("Random_level", random_level);

        }

        SceneManager.LoadScene(0);
    }

    public void Active_or_desactive(GameObject panel)
    {
        if (panel.activeInHierarchy)
        {
            panel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Exit()
    {
        
        Application.Quit();
    }
    public int Set_Get_score { get { return score; } set { score = value; } }
    public GameObject Set_panel_wins { get { return panel_wins; } set { panel_wins = value; } }
    public GameObject Set_panel_lose { get { return panel_lose; } set { panel_lose = value; } }
}
  
