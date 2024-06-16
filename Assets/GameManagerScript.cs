using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    public GameObject block2;
    public GameObject coin;
    public GameObject goal;
    public TextMeshProUGUI scoreText;
    public static int score = 0;
    public GameObject goalParticle;

    int[,] map;
    int[,] map2;
    // Start is called before the first frame update
    void Start()
    {
        map = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,},
            {1,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,3,2,1,},
            {1,0,0,0,0,0,0,1,0,1,},
            {1,0,0,3,3,0,1,0,0,1,},
            {1,1,1,1,1,1,1,1,1,1,},

        };

        map2 = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1, },
            {1,1,1,1,1,1,1,1,1,1, },
            {1,1,1,1,1,1,1,1,1,1, },
            {1,1,1,1,1,1,1,1,1,1, },
            {1,1,1,1,1,1,1,1,1,1, },
            {1,1,1,1,1,1,1,1,1,1, },
            {1,1,1,1,1,1,1,1,1,1, },
            {1,1,1,1,1,1,1,1,1,1, },
        };


        Vector3 position = Vector3.zero;

        for (int y = 0; y < map.GetLength(0); y++)
        {
            position.y = -y + 5;
            for (int x = 0; x < map.GetLength(1); x++)
            {
                position.x = x;
                if (map[y, x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }

                //ゴール位置設定
                if (map[y, x] == 2)
                {
                    goal.transform.position = position;
                    goalParticle.transform.position = position;
                }

                //コイン
                if ((map[y, x] == 3))
                {
                    Instantiate(coin, position, Quaternion.identity);
                }


            }
        }


        Vector3 position2 = Vector3.zero;
        for(int y = 0; y < map2.GetLength(0); y++)
        {
            for(int x = 0; x < map2.GetLength(1); x++)
            {
                position2.x = x;
                position2.y = -y + 5;
                position2.z = 3;
                Instantiate(block2, position2, Quaternion.identity);
            }
        }


    }
     
        // Update is called once per frame
        void Update()
        {

        scoreText.text = "SCORE" + score;

        //ゲームクリアでスペースキーでタイトル移項
        if (GoalScript.isGameClear == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("TitleScene");
                }
            }

        }
    
}