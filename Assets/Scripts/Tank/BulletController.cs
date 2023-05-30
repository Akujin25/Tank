using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BulletController : MonoBehaviour
{
    public Bullet Bullet { get; set; }
    public int MaxRange { get; set; }

    private bool isDestroyed = false;

    private void Update()
    {
        if (!isDestroyed)
        {
            MoveBullet();
        }
    }

    private void MoveBullet()
    {
        var currentPos = transform.position;
        var initPos = Bullet.InitialPosition;
        var direction = Bullet.Direction;

        var distance = Vector3.Distance(initPos, currentPos);

        if (distance >= MaxRange)
        {
            DestroyBullet();
            return;
        }

        Vector3 movement = Vector3.zero;

        switch (direction)
        {
            case Direction.Down:
                movement = Vector3.down;
                break;
            case Direction.Up:
                movement = Vector3.up;
                break;
            case Direction.Left:
                movement = Vector3.left;
                break;
            case Direction.Right:
                movement = Vector3.right;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        transform.position += movement * Time.deltaTime;
        CheckCollision();
    }

    public void CheckCollision()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("WallSteel"))
            {
                // Va chạm với "WallSteel", viên đạn biến mất
                Destroy(gameObject);
            }
            else if (collider.CompareTag("WaterTree"))
            {
                // Va chạm với "WaterTree", viên đạn đi xuyên qua
                return;
            }
            else if (collider.CompareTag("Brick"))
            {
                Tilemap tilemap = collider.GetComponent<Tilemap>();
                if (tilemap != null && tilemap.tag == "Brick")
                {
                    Vector3 hitPosition = transform.position;
                    Vector3Int cellPosition = tilemap.WorldToCell(hitPosition);

                    // Kiểm tra xem có WallBrick tại vị trí cell hay không
                    if (tilemap.GetTile(cellPosition) != null)
                    {
                        // Phá hủy WallBrick
                        tilemap.SetTile(cellPosition, null);

                        // Phá hủy viên đạn
                        Destroy(gameObject);
                        return; // Thoát khỏi hàm sau khi xử lý va chạm với WallBrick
                    }
                }
            }
        }
    }

    private void DestroyBullet()
    {
        isDestroyed = true;
        gameObject.SetActive(false);
    }
}