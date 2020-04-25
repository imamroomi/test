using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class shooting : MonoBehaviour
{
    // Start is called before the first frame update
    
    [System.Serializable]
public class bullets
    {

        public string tag;
        public GameObject prefab;
        public int size;
        public float speed;
    }
    public static shooting Instance;
    private void Awake()
    {
        Instance = this;
    }
        
    
    public List<bullets> type_of_bullets;
    public Dictionary<string, Queue<GameObject>> pooldictionary;
    void Start()
    {
       
        pooldictionary = new Dictionary<string, Queue<GameObject>>();


        for(int a=0;a<type_of_bullets.Count;a++)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            Debug.LogError(type_of_bullets[a].size);
            for(int b=0;b<type_of_bullets[a].size;b++)
            {
                GameObject obj = Instantiate(type_of_bullets[a].prefab);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }
            pooldictionary.Add(type_of_bullets[a].tag, objectpool);
        }
      
    }


    public GameObject spawn_from_pool(string tag,Vector3 position,Quaternion rotation)
    {
        GameObject bullet_to_spawn = pooldictionary[tag].Dequeue();
        bullet_to_spawn.SetActive(true);
        bullet_to_spawn.transform.position = position;
        bullet_to_spawn.transform.rotation = rotation;
        pooldictionary[tag].Enqueue(bullet_to_spawn);
        Debug.LogError("eeeeeeeeeeeeeeeeeeeeeee");
        return bullet_to_spawn;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
