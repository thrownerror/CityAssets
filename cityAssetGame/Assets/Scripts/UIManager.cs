using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum MenuType
{
    CREATE,
    UPGRADE,
    ATTACK
};

public class UIManager : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject storeImage;
    public GameObject houseImage;
    public GameObject domeImage;

    public List<GameObject> createMenuItems;
    public List<GameObject> upgradeMenuItems;
    public List<GameObject> attackMenuItems;

    public GameObject genericHousePrefab;
    public GameObject ammoPrefab;
    public GameObject resourcePrefab;

    public List<GameObject> imageInstances;
    public bool isShowingMenu = false;

    GridScript gridInstance;   

    bool isOver;

    void Start()
    {
        gridInstance = GameObject.Find("Grid").GetComponent<GridScript>();
    }

    void Update()
    {

    }

    void ShowCreationMenu()
    {
        var pos = transform.parent.transform.position;
        float x = pos.x;
        GameObject instance = null;
        bool firstDone = false;
        foreach (var item in createMenuItems)
        {
            instance = Instantiate(item, transform.parent);
            pos = instance.transform.position;
            if (!firstDone) x = pos.x;
            x += 50;
            instance.transform.position = new Vector3(x, pos.y, pos.z);
            imageInstances.Add(instance);
            firstDone = true;
        }
    }

    void ShowUpgradeMenu()
    {
        var pos = transform.parent.transform.position;
        float x = pos.x;
        GameObject instance = null;
        bool firstDone = false;
        foreach (var item in upgradeMenuItems)
        {
            instance = Instantiate(item, transform.parent);
            pos = instance.transform.position;
            if (!firstDone) x = pos.x;
            x += 50;
            instance.transform.position = new Vector3(x, pos.y, pos.z);
            imageInstances.Add(instance);
            firstDone = true;
        }
    }

    void ShowAttackMenu()
    {
        var pos = transform.parent.transform.position;
        float x = pos.x;
        GameObject instance = null;
        bool firstDone = false;
        foreach (var item in attackMenuItems)
        {
            instance = Instantiate(item, transform.parent);
            pos = instance.transform.position;
            if (!firstDone) x = pos.x;
            x += 30;
            instance.transform.position = new Vector3(x, pos.y, pos.z);
            imageInstances.Add(instance);
            firstDone = true;
        }

    }

    void ShowMenu()
    {
        MenuType menuType = MenuType.CREATE;
        switch (menuType)
        {
            case MenuType.CREATE:
                ShowCreationMenu();
                break;
            case MenuType.ATTACK:
                ShowAttackMenu();
                break;
            case MenuType.UPGRADE:
                ShowUpgradeMenu();
                break;
        }
    }

    void CollapseMenu()
    {
        foreach (var item in imageInstances)
        {
            DestroyImmediate(item);
        }
        imageInstances.Clear();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        isShowingMenu = !isShowingMenu;
        if (isShowingMenu)
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
