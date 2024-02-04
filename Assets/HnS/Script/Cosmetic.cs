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

    Color shoescolor, glasscolor;

    Renderer shoesRenderer, glassRenderer;
    // Start is called before the first frame update

    private void Awake()
    {
        shoesRenderer = shoes.GetComponent<Renderer>();
        glassRenderer = glass.GetComponent<Renderer>();
    }
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

        shoescolor = new Color(RandomNumber(), RandomNumber(), RandomNumber());

        shoesRenderer.material.SetColor("_Color", shoescolor);
        shoesButton.gameObject.GetComponent<Image>().color = shoescolor;

    }

    void GlassColor()
    {
        glasscolor = new Color(RandomNumber(), RandomNumber(), RandomNumber());

        glassRenderer.material.SetColor("_Color", glasscolor);
        glassButton.gameObject.GetComponent<Image>().color = glasscolor;

    }

    void ShoesSave(float x, float y, float z, int condition)
    {
        shoescolor = new Color(x, y, z);

        shoesRenderer.material.SetColor("_Color", shoescolor);
        shoesButton.gameObject.GetComponent<Image>().color = shoescolor;

        shoes.gameObject.SetActive(condition == 1 ? true:false);
        ShoesToggle.isOn = condition == 1 ? true : false;

        Debug.Log("loadshoes");
    }

    void GlassSave(float x, float y, float z,int condition)
    {
        glasscolor = new Color(x, y, z);

        glassRenderer.material.SetColor("_Color", glasscolor);
        glassButton.gameObject.GetComponent<Image>().color = glasscolor;

        glass.gameObject.SetActive(condition == 1 ? true : false);
        glassToggle.isOn = condition == 1 ? true : false;

        Debug.Log("loadglass");
    }

    float RandomNumber()
    {
        float temp = Random.Range(0f, 1f);
        return temp;
    }

    public void LoadPrefecence()
    {
        if (!Check()) return;
        
        ShoesSave(PlayerPrefs.GetFloat("ColorShoes1"),PlayerPrefs.GetFloat("ColorShoes2"), PlayerPrefs.GetFloat("ColorShoes3"), PlayerPrefs.GetInt("ActiveShoes"));
        GlassSave(PlayerPrefs.GetFloat("ColorGlass1"), PlayerPrefs.GetFloat("ColorGlass2"), PlayerPrefs.GetFloat("ColorGlass3"), PlayerPrefs.GetInt("ActiveGlass"));
    }


    public void SavePreference()
    {
        PlayerPrefs.SetInt("ActiveShoes", IsShoesOn == true ? 1 : 0);
        
        PlayerPrefs.SetInt("ActiveGlass", isGlassOn == true ? 1 : 0);



        PlayerPrefs.SetFloat("ColorShoes1", shoescolor.r);
        PlayerPrefs.SetFloat("ColorShoes2", shoescolor.g);
        PlayerPrefs.SetFloat("ColorShoes3", shoescolor.b);
        PlayerPrefs.SetFloat("ColorGlass1", glasscolor.r);
        PlayerPrefs.SetFloat("ColorGlass2", glasscolor.g);
        PlayerPrefs.SetFloat("ColorGlass3", glasscolor.b);


        //PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    bool Check()
    {
        if(!PlayerPrefs.HasKey("ColorShoes1") || !PlayerPrefs.HasKey("ColorShoes2") || !PlayerPrefs.HasKey("ColorShoes3"))
        {
            Debug.Log("shoes");
            return false; 
        }
        
        if (!PlayerPrefs.HasKey("ColorGlass1") || !PlayerPrefs.HasKey("ColorGlass2") || !PlayerPrefs.HasKey("ColorGlass3"))
        {

            Debug.Log("glass");
            return false; 
        }
        
        if(!PlayerPrefs.HasKey("ActiveShoes") || !PlayerPrefs.HasKey("ActiveGlass"))
        {

            Debug.Log("active");
            return false;
        }

        Debug.Log("check");
        return true;
    }
}
