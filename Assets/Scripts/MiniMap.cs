/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Transform playerTransfrom;
    public RawImage miniMapImage;

    private RectTransform miniMapRectTransform;
    private Vector2 miniMapSize;

    // Start is called before the first frame update
    void Start()
    {
        miniMapRectTransform = miniMapImage.GetComponent<RectTransform>();
        miniMapSize = miniMapRectTransform.rect.size;
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾� ��ġ�� �̴ϸ� UI ��ǥ�� ��ȯ�Ͽ� �÷��̾� ������ ��ġ ������Ʈ
        Vector2 miniMapPosition = WorldToMiniMapPosition(playerTransform.position);
        UpdatePlayerIconPosition(miniMapPosition);
    }

    private Vector2 WorldToMiniMapPosition(Vector3 worldPosition)
    {
        // ���� ���� ��ǥ�� �̴ϸ� UI ��ǥ�� ��ȯ
        Vector2 miniMapCenter = miniMapRectTransform.anchoredPosition;
        Vector2 miniMapScale = miniMapRectTransform.localScale;
        Vector2 miniMapOffset = miniMapSize * 0.5f;

        Vector2 worldToMiniMapRatio = miniMapSize / worldBounds.size; // ����� �̴ϸ��� ���� ���
        Vector2 relativePosition = (worldPosition - worldBounds.min) * worldToMiniMapRatio; // ������� ��ġ ���
        Vector2 miniMapPosition = miniMapCenter + (relativePosition - miniMapOffset) * miniMapScale; // �̴ϸ� ���� ��ġ ���

        return miniMapPosition;
    }

    private void UpdatePlayerIconPosition(Vector2 miniMapPosition)
    {
        // �÷��̾� ������ ��ġ ������Ʈ
        RectTransform playerIconRectTransform = playerIcon.GetComponent<RectTransform>();
        playerIconRectTransform.anchoredPosition = miniMapPosition;
    }
}*/