using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject storeImage;
    public GameObject houseImage;
    public GameObject domeImage;

    public GameObject genericHousePrefab;
    public GameObject ammoPrefab;
    public GameObject resourcePrefab;

    public List<GameObject> imageInstances;
    public bool isShowingMenu = false;

    bool isOver;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShowMenu()
    {
        var instance = Instantiate(storeImage, transform.parent);
        imageInstances.Add(instance);
        var x = instance.transform.position.x;
        x += 40;
        var pos = instance.transform.position;
        instance.transform.position = new Vector3(x, pos.y, pos.z);
        instance = Instantiate(domeImage, transform.parent);
        imageInstances.Add(instance);
        pos = instance.transform.position;
        x += 50;
        instance.transform.position = new Vector3(x, pos.y, pos.z);
        instance = Instantiate(houseImage, transform.parent);
        imageInstances.Add(instance);
        pos = instance.transform.position;
        x += 50;
        instance.transform.position = new Vector3(x, pos.y, pos.z);
    }

    void CollapseMenu()
    {
        foreach(var item in imageInstances)
        {
            DestroyImmediate(item);
        }
        imageInstances.Clear();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        isShowingMenu = !isShowingMenu;
        if(isShowingMenu)
        {
            ShowMenu();
        }
        else
        {
            CollapseMenu();
        }     
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
        isOver = false;
    }
}
