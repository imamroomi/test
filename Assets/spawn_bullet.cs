using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            shooting.Instance.spawn_from_pool("player_bullet", this.transform.position, this.transform.rotation);
        }
    }
}
