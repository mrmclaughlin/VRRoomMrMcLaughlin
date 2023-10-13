using UnityEngine;

public class SingleAudioListener : MonoBehaviour
{
    private static bool exists;

    void Start()
    {
        if (exists)
        {
            Destroy(GetComponent<AudioListener>());
        }
        else
        {
            exists = true;
            //DontDestroyOnLoad(gameObject);
        }
    }
}
