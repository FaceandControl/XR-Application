using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PreviewListControl : MonoBehaviour
{
    public Text accountLogin;
    public GameObject listItemTemplate;
    public IList<PreviewItem> previewItems;

    public void Populate(IEnumerable<PreviewItem> previewItems)
    {
        foreach (var previewItem in previewItems)
        {
            var item = Instantiate(listItemTemplate, transform);
            item.GetComponentInChildren<Text>().text = previewItem.Image;
            item.transform.Find("PreviewImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(previewItem.Image);
        }
    }

    public void Clean()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Clean();
        accountLogin.text = AccountManager.AccountLogin;
        previewItems = GetFackedPreviewItems();
        Populate(previewItems);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickOnSaved() 
    {
        Clean();
        Populate(previewItems.Where(x => x.IsSaved == true));
    }

    public void ClickOnAll()
    {
        Clean();
        Populate(previewItems);
    }

    public static List<PreviewItem> GetFackedPreviewItems()
    {
        return new List<PreviewItem>()
        {
            new PreviewItem()
            {
                Image = "Mario",
                IsSaved = false,
            },
            new PreviewItem()
            {
                Image = "apple",
                IsSaved = false,
            },
            new PreviewItem()
            {
                Image = "duck",
                IsSaved = true,
            },
            new PreviewItem()
            {
                Image = "linux",
                IsSaved = true,
            }
        };
    }
}

public class PreviewItem : MonoBehaviour
{
    public string Image { get; set; }
    public bool IsSaved { get; set; }
}
