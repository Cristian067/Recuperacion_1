using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.x >= 18 || transform.position.x <= -18)
        {
            Destroy(gameObject);
        }

        //transform.Rotate(new Vector3(0, 0, 1) * 10 * Time.deltaTime,Space.World);

        if (!player.isGameOver)
        {
            transform.Translate(new Vector3(-1, 0, 0) * 10 * Time.deltaTime);

        }
        


        
    }
}
