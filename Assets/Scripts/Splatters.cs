using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splatters : MonoBehaviour
{

    public static Splatters instance;

    private void Awake()
    {
        if(instance == null)
        instance = this;
                   
    }

    [SerializeField] Color[] colors = new Color[2];
    [SerializeField] GameObject splatterPrefab;
    [SerializeField] Sprite[] splatterSprites;

    //private void Start()
    //{
    //    Instantiate(splatterPrefab);
    //}
    // Start is called before the first frame update
    public void AddSplatter(Transform obstacle, Vector3 pos, int colorIndex)
    {
        var splatter = Instantiate(splatterPrefab, pos, Quaternion.identity, obstacle);

        SpriteRenderer sr = splatter.GetComponent<SpriteRenderer>();
        sr.color = colors[colorIndex];
        sr.sprite = splatterSprites[Random.Range(0, splatterSprites.Length)];

    }

   
}
