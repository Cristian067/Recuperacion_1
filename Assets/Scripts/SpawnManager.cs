using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject bombL;
    [SerializeField] private GameObject bombR;

    [SerializeField] private GameObject[] item;

    private PlayerControl player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<PlayerControl>();

        InvokeRepeating("bombs", 1, 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }


    private void bombs()
    {
        int randomN = Random.Range(2, 15);
        int randomI = Random.Range(0, item.Length);
        int randomS = Random.Range(0, 2);

        if(!player.isGameOver)
        {
            if (randomS == 0)
            {
                Instantiate(item[randomI], new Vector3(-16, randomN, 0), Quaternion.Euler(0, 180, 0));
            }
            if (randomS == 1)
            {
                Instantiate(item[randomI], new Vector3(16, randomN, 0), Quaternion.identity);
            }
            //Instantiate(bomb, new Vector3(16,randomN,0), Quaternion.identity);


        }


    }



}
