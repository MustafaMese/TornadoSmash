using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    [SerializeField] float speed;

    private void Start() 
    {
        DOTween.Init();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Raiser")
        {
            Transform target = other.transform;
            transform.DOMoveY(target.transform.position.y + 1, 1f);
            transform.DOScale(Vector3.one * 0.01f, 0.5f).OnComplete(() => {
               this.gameObject.SetActive(false);
            });
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Puller")
        {
            Transform target = other.transform;
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        }
    }
}
