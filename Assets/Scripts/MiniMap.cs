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
        // 플레이어 위치를 미니맵 UI 좌표로 변환하여 플레이어 아이콘 위치 업데이트
        Vector2 miniMapPosition = WorldToMiniMapPosition(playerTransform.position);
        UpdatePlayerIconPosition(miniMapPosition);
    }

    private Vector2 WorldToMiniMapPosition(Vector3 worldPosition)
    {
        // 게임 월드 좌표를 미니맵 UI 좌표로 변환
        Vector2 miniMapCenter = miniMapRectTransform.anchoredPosition;
        Vector2 miniMapScale = miniMapRectTransform.localScale;
        Vector2 miniMapOffset = miniMapSize * 0.5f;

        Vector2 worldToMiniMapRatio = miniMapSize / worldBounds.size; // 월드와 미니맵의 비율 계산
        Vector2 relativePosition = (worldPosition - worldBounds.min) * worldToMiniMapRatio; // 상대적인 위치 계산
        Vector2 miniMapPosition = miniMapCenter + (relativePosition - miniMapOffset) * miniMapScale; // 미니맵 상의 위치 계산

        return miniMapPosition;
    }

    private void UpdatePlayerIconPosition(Vector2 miniMapPosition)
    {
        // 플레이어 아이콘 위치 업데이트
        RectTransform playerIconRectTransform = playerIcon.GetComponent<RectTransform>();
        playerIconRectTransform.anchoredPosition = miniMapPosition;
    }
}*/