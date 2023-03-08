using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    private double start;
    Rigidbody m_Rigidbody;
    public GameObject target;
    public AudioSource audioSource;
    public AudioClip crashSound;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = crashSound;
        audioSource.Play();
        start = Time.realtimeSinceStartup;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // transform.position = moveSpeed * Time.deltaTime * transform.forward;


        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > 120)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
        } else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", true);
        }
        //var lookPos = target.transform.position - transform.position;
        //var rotation = Quaternion.LookRotation(lookPos);
        //rotation.y = 0;
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 10F * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    if (currentPoints <= 30)
        //    {
        //        SceneManager.LoadScene("GameEndScene");
        //    }
        //    else
        //    {
        //        Debug.Log("Car ran into obstacle");
        //        audioSource.clip = crashSound;
        //        audioSource.Play();
        //        currentPoints -= 30;
        //        points.text = currentPoints.ToString();
        //    }
        //}
        //else if (other.gameObject.CompareTag("Goal"))
        //{
        //    Debug.Log("Car reached destination");
        //    audioSource.clip = clapSound;
        //    audioSource.Play();
        //}

    }
}
