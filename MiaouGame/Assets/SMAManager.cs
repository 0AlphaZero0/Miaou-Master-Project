using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMAManager : MonoBehaviour
{
    public static SMAManager instance = null;

    public SMAAgent[] m_agents;

    void Awake(){
        m_agents = FindObjectsOfType<SMAAgent>();
        if (instance==null){
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(SMAAgent currentAgent in m_agents){
            currentAgent.SMAUpdate(Time.deltaTime);
        }
    }

    void FixedUpdate(){
        foreach(SMAAgent currentAgent in m_agents){
            currentAgent.SMAFixedUpdate (Time.fixedDeltaTime);
        }
    }
}
