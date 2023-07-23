using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class DialogueScript : MonoBehaviour
{
    public GameObject Player;

    public AudioSource audio1;
    public AudioSource audio2;
    bool audio1Started = false;
    bool audio2Started = false;

    MultiAimConstraint aim;
    RigBuilder rigBuilder;

    //public Transform npcPosition;
    //public float checkRadius;
    //public LayerMask playerLayer;

    public float timeBetweenLines = 1f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        aim = GetComponent<MultiAimConstraint>();
        rigBuilder = GetComponent<RigBuilder>();
    }

    private void Update()
    {
        if (!audio1.isPlaying && audio1Started && !audio2Started)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenLines && audio2 != null)
            {
                audio2.Play();
                audio2Started = true;
            }
        }

    }

    public void Interact()
    {
        if (!audio1Started)
        {
            audio1.Play();
            audio1Started = true;

            
            
        }
    }

    void SetAimTarget()
    {
        var data = aim.data.sourceObjects;
        data.Clear();
        data.Add(new WeightedTransform(Player.transform, 1));
        aim.data.sourceObjects = data;
        rigBuilder.Build();
    }

    //public override void OnFocus()
    //{

    //}

    //public override void OnInteract()
    //{
    //    SetLookTarget();
    //    audio1.Play();
    //    audioStarted = true;
    //}

    //public override void OnLoseFocus()
    //{

    //}

    //void SetLookTarget()
    //{
    //    var data = mac.data.sourceObjects;
    //    data.Clear();
    //    data.Add(new WeightedTransform(Player.transform, 1));
    //    mac.data.sourceObjects = data;
    //    rig.Build();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            //SetAimTarget();       
            Interact();
        }
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void Interact()
    //{
    //    audio.Play();
    //    audioStarted = true;


    //}


}
