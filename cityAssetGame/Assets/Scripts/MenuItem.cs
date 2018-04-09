using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public enum ItemType
    {
        AMMO_GEN,
        GENERIC,
        RESOURCE_GEN
    };

    public MenuType menuType;
    public ItemType itemType;

    public UIManager uiManager;

    void Start()
    {
        uiManager = transform.parent.GetComponentInChildren<UIManager>();
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
        CreateItem(selectedGrid, prefab);
    }

    void CreateAmmoItem(GameObject selectedGrid)
    {
        var prefab = uiManager.ammoPrefab.GetComponent<SpriteRenderer>();
        CreateItem(selectedGrid, prefab);
    }

    void CreateResourceItem(GameObject selectedGrid)
    {
        var prefab = uiManager.resourcePrefab.GetComponent<SpriteRenderer>();
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
        if (selectedGridItem != null)
        {
            //Debug.Log("Click " + selectedGridItem.name);
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
    }
}
