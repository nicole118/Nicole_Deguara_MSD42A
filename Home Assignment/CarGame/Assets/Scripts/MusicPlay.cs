using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SettingUpSingleton();
    }

    private void SettingUpSingleton()
    {
        // if there is more than one music player object, destroy it
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            //if there's only one music player object, keep the music going
            DontDestroyOnLoad(gameObject);
        }

    }

}
