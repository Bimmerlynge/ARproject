using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeUIController : MonoBehaviour
{
    [SerializeField]
    private DemandsController[] demands;

    [SerializeField]
    private GameObject body, footer, iconPrefab;

    private int pageIndex = 0;

    private void Awake()
    {
        demands = body.GetComponentsInChildren<DemandsController>();
    }

 

    public void EnableUI() {
        pageIndex = 0;
        Init();
    }

    private void Init() {
        foreach (var page in demands) { 
            page.gameObject.SetActive(false);
        }
        EnablePage(pageIndex);
    }

    private void EnablePage(int index) {
        footer.transform.GetChild(index).GetComponent<Image>().color = Color.white;
        body.transform.GetChild(index).gameObject.SetActive(true);
    }

    private void DisablePage(int index) {
        footer.transform.GetChild(index).GetComponent<Image>().color = Color.black;
        body.transform.GetChild(index).gameObject.SetActive(false);

    }

    public void NextPage() { 
        DisablePage(pageIndex);
        UpdatePageIndex();
        EnablePage(pageIndex);
    }

    private void UpdatePageIndex() { 
        pageIndex = (pageIndex + 1) % demands.Length;
    }
}
