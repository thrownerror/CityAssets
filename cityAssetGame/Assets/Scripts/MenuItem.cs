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
    private EnemyScript enemy;

    public int GenericCost = 1;
    public int AmmoGeneratorCost = 2;
    public int ResourceGeneratorCost = 2;

    void Start()
    {
        uiManager = transform.parent.GetComponentInChildren<UIManager>();
        cityManager = GameObject.Find("CityManager").GetComponent<citymanager>();
        enemy = GameObject.Find("Enemy").GetComponent<EnemyScript>();
    }

    void Update()
    {

    }

    void AttackEnemy()
    {
        var grid = GameObject.Find("Battle Grid").GetComponent<GridScript>();
        enemy.ShootEnemy(grid.SelectedGrid);
        cityManager.ammo--;
        Debug.Log("Attack");
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

    int GetItemTypeCost()
    {
        switch (itemType)
        {
            case ItemType.GENERIC:
                return GenericCost;
            case ItemType.RESOURCE_GEN:
                return ResourceGeneratorCost;
            case ItemType.AMMO_GEN:
                return AmmoGeneratorCost;
        }

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (menuType == MenuType.ATTACK)
        {
            if (cityManager.IncrementTurn())
            {
                AttackEnemy();
            }
            return; //No need to go further since Player Grid is disabled. 
        }

        var selectedGridItem = GetSelectedGridItem();
        var unit = selectedGridItem.GetComponent<UnitScript>();
        if (menuType == MenuType.CREATE && unit == null)
        {
            if (cityManager.resource >= GetItemTypeCost()) //If we have actions left in current turn.
            {
                if (selectedGridItem != null && cityManager.IncrementTurn())
                {
                    switch (itemType)
                    {
                        case ItemType.GENERIC:
                            CreateGenericItem(selectedGridItem);
                            cityManager.resource -= GenericCost;
                            break;
                        case ItemType.AMMO_GEN:
                            CreateAmmoItem(selectedGridItem);
                            cityManager.resource -= AmmoGeneratorCost;

                            break;
                        case ItemType.RESOURCE_GEN:
                            CreateResourceItem(selectedGridItem);
                            cityManager.resource -= ResourceGeneratorCost;
                            break;
                    }
                }
            }
        }
        else if (menuType == MenuType.UPGRADE)
        {
            Debug.Log("Upgrade " + unit.unitLevel);
            if (unit.CanUpgrade())
            {
                if (cityManager.IncrementTurn())
                {
                    unit.UpgradeLevel();
                }
            }
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
