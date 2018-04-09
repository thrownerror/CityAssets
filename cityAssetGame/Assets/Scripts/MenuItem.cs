using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum ItemType
{
    AMMO_GEN,
    GENERIC,
    RESOURCE_GEN
};

public class MenuItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public MenuType menuType;
    public ItemType itemType;

    public UIManager uiManager;
    private citymanager cityManager;

    void Start()
    {
        uiManager = transform.parent.GetComponentInChildren<UIManager>();
        cityManager = GameObject.Find("CityManager").GetComponent<citymanager>();
    }

    void Update()
    {

    }

    GameObject GetSelectedGridItem()
    {
        var grid = GameObject.Find("Grid").GetComponent<GridScript>();
        if (grid.HasOneGridSelected)
        {
            var selected = grid.SelectedGrid;
            return GameObject.Find(selected);
        }

        return null;
    }

    void CreateGenericItem(GameObject selectedGrid)
    {
        var prefab = uiManager.genericHousePrefab.GetComponent<SpriteRenderer>();
        var unit = selectedGrid.gameObject.AddComponent<UnitScript>();
        unit.currentCell = selectedGrid.name;
        unit.unitType = ItemType.GENERIC;
        unit.Init();
        cityManager.AddUnit(unit.currentCell, unit);
        CreateItem(selectedGrid, prefab);

    }

    void CreateAmmoItem(GameObject selectedGrid)
    {
        var prefab = uiManager.ammoPrefab.GetComponent<SpriteRenderer>();
        var unit = selectedGrid.gameObject.AddComponent<UnitScript>();
        unit.currentCell = selectedGrid.name;
        unit.unitType = ItemType.AMMO_GEN;
        cityManager.AddUnit(unit.currentCell, unit);
        unit.Init();
        CreateItem(selectedGrid, prefab);
    }

    void CreateResourceItem(GameObject selectedGrid)
    {
        var prefab = uiManager.resourcePrefab.GetComponent<SpriteRenderer>();
        var unit = selectedGrid.gameObject.AddComponent<UnitScript>();
        unit.currentCell = selectedGrid.name;
        cityManager.AddUnit(unit.currentCell, unit);
        unit.unitType = ItemType.RESOURCE_GEN;
        unit.Init();
        CreateItem(selectedGrid, prefab);
    }

    void CreateItem(GameObject selectedGrid, SpriteRenderer prefab)
    {
        var spriteRenderer = selectedGrid.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = prefab.sprite;
        spriteRenderer.gameObject.transform.localPosition = new Vector3(0, 0, -0.55F);
        spriteRenderer.gameObject.transform.localScale = new Vector3(0.25F, 0.25F, 0.25F);
        Debug.Log(spriteRenderer.gameObject.name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var selectedGridItem = GetSelectedGridItem();
        if (menuType == MenuType.CREATE)
        {
            if (cityManager.IncrementTurn()) //If we have actions left in current turn.
            {
                if (selectedGridItem != null)
                {
                    switch (itemType)
                    {
                        case ItemType.GENERIC:
                            CreateGenericItem(selectedGridItem);
                            break;
                        case ItemType.AMMO_GEN:
                            CreateAmmoItem(selectedGridItem);
                            break;
                        case ItemType.RESOURCE_GEN:
                            CreateResourceItem(selectedGridItem);
                            break;
                    }
                }
            }
        }
        else if (menuType == MenuType.UPGRADE)
        {
            var unit = selectedGridItem.GetComponent<UnitScript>();
            Debug.Log("Upgrade " + unit.unitLevel);
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
    }
}
