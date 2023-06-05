using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PreviewPanelClick : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() 
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        var chosenImage = this.GetComponent<Image>();
        Debug.Log(chosenImage.sprite.name);
        PlayerPrefs.SetString("image", chosenImage.sprite.name);
        SceneManager.LoadScene("Meshing");
//        var image = pointerEventData.hovered.First(h => h.name == "PreviewImage").GetComponent<Image>();

    }
}
