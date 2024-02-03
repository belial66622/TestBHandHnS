using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cosmetic : MonoBehaviour
{
    [SerializeField]
    Toggle glassToggle;

    [SerializeField]
    Toggle ShoesToggle;

    [SerializeField]
    Button glassButton;

    [SerializeField]
    Button shoesButton;
    
    [SerializeField]
    GameObject glass;

    [SerializeField]
    GameObject shoes;

    [SerializeField]
    bool isGlassOn = false;

    [SerializeField]
    bool IsShoesOn = false;

    // Start is called before the first frame update
    void Start()
    {
        glassToggle.onValueChanged.AddListener(GlassActive) ;
        ShoesToggle.onValueChanged.AddListener(ShoesActive);
        glassButton.onClick.AddListener(GlassColor);
        shoesButton.onClick.AddListener(ShoesColor);
    }


    void GlassActive(bool condition)
    { 
        isGlassOn= condition;
        glass.gameObject.SetActive(isGlassOn);
    }

    void ShoesActive(bool condition)
    { 
        IsShoesOn= condition;
        shoes.gameObject.SetActive(IsShoesOn);
    }

    void ShoesColor()
    {
       Color newcolor = new Color(RandomNumber(), RandomNumber(), RandomNumber());  
        Renderer temp = shoes.GetComponent<Renderer>();
        temp.material.SetColor("_Color",newcolor);
        shoesButton.gameObject.GetComponent<Image>().color = newcolor;
    }

    void GlassColor()
    {
        Color newcolor = new Color(RandomNumber(), RandomNumber(), RandomNumber());
        Renderer temp = glass.GetComponent<Renderer>();
        temp.material.SetColor("_Color", newcolor);
        glassButton.gameObject.GetComponent<Image>().color = newcolor;
    }


    float RandomNumber()
    {
        float temp = Random.Range(0f, 1f);
        return temp;
    }
}
