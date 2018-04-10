using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum MenuType
{
    CREATE,
    UPGRADE,
    ATTACK,
    REPAIR
};

public class UIManager : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	public AudioSource MusicSource;

	public AudioClip[] MusicClips;

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

    private GridScript gridInstance;
    private citymanager cityManager;

    bool isMouseOver;

    void Start()
    {
        gridInstance = GameObject.Find("Grid").GetComponent<GridScript>();
        cityManager = GameObject.Find("CityManager").GetComponent<citymanager>();


    }

    void Update()
    {
		
    }

    GameObject GetSelectedGridItem()
    {
        if (gridInstance.HasOneGridSelected)
        {
            var selected = gridInstance.SelectedGrid;
            return GameObject.Find(selected);
        }

        return null;
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

    void ShowMenu(MenuType menuType)
    {
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

    public void CollapseMenu()
    {
        foreach (var item in imageInstances)
        {
            DestroyImmediate(item);
        }
        imageInstances.Clear();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
		

        var selectedCell = GetSelectedGridItem();
        var type = MenuType.CREATE;
        var unit = selectedCell != null ? selectedCell.GetComponent<UnitScript>() : null;
        if (selectedCell != null && unit != null)
        {
            type = MenuType.UPGRADE;
			SoundChange (1);
        }

        if(cityManager.gridSwitch)
        {
            type = MenuType.ATTACK;
        }

        isShowingMenu = !isShowingMenu;
        if (isShowingMenu && selectedCell != null)
        {
            ShowMenu(type);
        }
        else
        {
            CollapseMenu();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }

	public void SoundChange(int temp)
	{
		MusicSource.clip = MusicClips [temp];

		MusicSource.Play ();	
	}
}
