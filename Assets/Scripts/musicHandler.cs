using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicHandler : MonoBehaviour
{

    [SerializeField] private AudioSource splashMusic;
    [SerializeField] private AudioSource gameMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        int numMusicPlayers = FindObjectsOfType<musicHandler>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
