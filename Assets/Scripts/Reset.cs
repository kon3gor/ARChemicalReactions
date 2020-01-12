using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public GameObject H;
    public GameObject S;
    public GameObject N;
    public GameObject C;
    private List<GameObject> elements;

    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(OnClick);
        elements = new List<GameObject>() { H, S,  N, C };
    }

    void OnClick()
    {
        foreach (var el in elements) {
            el.transform.GetComponent<Element>().ChangeState(0);
        }
    }
}
