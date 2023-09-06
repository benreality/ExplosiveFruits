using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    public Dictionary<string, AudioClip> dic;

    [SerializeField]
    AudioClip[] clip;

    [SerializeField]
    string[] clipname;

    public static AudioController instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        dic = new Dictionary<string, AudioClip>();

        for(int i = 0; i < clipname.Length; ++i)
        {
            dic.Add(clipname[i], clip[i]);
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
