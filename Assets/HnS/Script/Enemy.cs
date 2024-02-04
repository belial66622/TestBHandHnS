using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class Enemy : MonoBehaviour, IEnemy
{

    public bool Alert { get; set; } = false;

    private Renderer render = null;

    private Coroutine delay = null;

    private Coroutine delayyellow = null;

    private EnemyManager manager = null ;

    private bool caution = false;

    [SerializeField]
    private float spreadDistance = 10.0f;

    private void Awake()
    {
        render = GetComponent<Renderer>();

        manager = GetComponentInParent<EnemyManager>();
    }

    private void Start()
    {
        manager.RegisterEnemies(this);
    }

    public void AlertSpread(Transform t)
    {
        if (caution)
        { 
            caution = false;
            if (delayyellow != null)
            {
                StopCoroutine(delayyellow);
                delayyellow = null;
            }
        }

        if (delay != null)
        {
            StopCoroutine(delay);
            delay = null;
            delay= StartCoroutine(Delay());
        }

        if (Alert) return;
        if (Vector3.Distance(t.position, transform.position) < spreadDistance)
        {
            render.material.SetColor("_Color", Color.red);
            delay =StartCoroutine(Delay());
            Spreadcommand();
        }
    }

    public void Spreadcommand()
    {
        manager.SpreadAlert(transform);
    }

    public void Caution()
    {
        if (Alert) return;

        if (delayyellow != null)
        {
            StopCoroutine(delayyellow);
            delayyellow = StartCoroutine(DelayYellow());
        }

        if (caution) return;
        render.material.SetColor("_Color", Color.yellow);

        delayyellow = StartCoroutine(DelayYellow());
    }

    IEnumerator Delay()
    {
        Alert = true;
        yield return new WaitForSeconds(5);
        Alert = false;
        delay = null;
        render.material.SetColor("_Color", Color.white);

    }

    IEnumerator DelayYellow()
    {
        caution = true;
        yield return new WaitForSeconds(5);
        Alert = false;
        delayyellow = null;
        render.material.SetColor("_Color", Color.white);

    }
}
