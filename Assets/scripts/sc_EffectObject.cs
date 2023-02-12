using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_EffectObject : MonoBehaviour
{
    public float Lifetime;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("noteHolder").GetComponent<sc_BeatScroller>().isMirrored == true)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, Lifetime);
    }
}
